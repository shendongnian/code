    <Window x:Class="WpfApplication1.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:local="clr-namespace:WpfApplication1"
            Title="MainWindow" Height="350" Width="525">
        <Window.Resources>
            <local:Con x:Key="abc" />
        </Window.Resources>
        <Grid>
            <Rectangle StrokeThickness="{Binding abc, Converter={StaticResource abc}}"/>
        </Grid>
    </Window>
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = new { abc = new Thickness(4) };
            }
        }    
        public class Con : IValueConverter
        {
            public object Convert(object value, Type targetType, 
                                  object parameter, 
                                  System.Globalization.CultureInfo culture)
            {
                return ((Thickness)value).Left;
            }
            public object ConvertBack(object value, 
                                      Type targetType, 
                                      object parameter, 
                                      System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
