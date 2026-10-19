using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string hotel = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalendarArrival_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CalendarArrival.SelectedDate.HasValue && CalendarLeave.SelectedDate.HasValue)
            {
                TextNights.Text = $"NIGHT: {(CalendarLeave.SelectedDate.Value - CalendarArrival.SelectedDate.Value).Days}";
            }
        }

        private void CalendarLeave_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CalendarArrival.SelectedDate.HasValue && CalendarLeave.SelectedDate.HasValue)
            {
                TextNights.Text = $"NIGHT: {(CalendarLeave.SelectedDate.Value - CalendarArrival.SelectedDate.Value).Days}";
            }
        }


        private void malonir(object sender, RoutedEventArgs e)
        {
            int sum = 0;
            int price=0;
            if(hotel==null || !(CalendarArrival.SelectedDate.HasValue) || !(CalendarLeave.SelectedDate.HasValue))
            {
                if (hotel == "Leonardo Club")
                    price = 400;
                else if (hotel == "Malkat Shva")
                    price = 600;
                else
                    price = 800;
                for (DateTime i = CalendarArrival.SelectedDate.Value; i < CalendarLeave.SelectedDate.Value; i = i.AddDays(1))
                {
                    if (i.DayOfWeek == DayOfWeek.Saturday)
                        sum += 2 * price;
                    else
                        sum += price;
                }
                TextPrice.Text = $"PRICE: {sum}$";
            }
        }

        private void hotelnirselected(object sender, SelectionChangedEventArgs e)
        {
            if (comboboxhotel.SelectedItem is ComboBoxItem selecteditem)
                hotel = selecteditem.Content.ToString();
        }
    }
}