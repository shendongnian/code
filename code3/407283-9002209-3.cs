        using System.Windows;
        using System.Windows.Data;
    
        namespace GridTest
        {
            /// <summary>
            /// Interaction logic for MainWindow.xaml
            /// </summary>
            public partial class MainWindow : Window
            {
                public MainWindow()
                {
                    InitializeComponent();
                }
            }
        
            public class FourWidthConverter : IValueConverter
            {
                public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
                {
                    return 4 * (double)value;
                }
        
                public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
                {
                    throw new System.NotImplementedException();
                }
            }
        }
