    using System;
    using System.Windows;
    using System.Windows.Data;
    namespace WpfApplication1
        {
            /// <summary>
            /// Interaktionslogik für MainWindow.xaml
            /// </summary>
            public partial class MainWindow : Window
            {
                public MainWindow()
                {
                    InitializeComponent();
                }
            }
            public class WidthConverter : IValueConverter
            {
                public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
                {
                    if (!(value is double))
                    {
                        return Binding.DoNothing;
                    }
                    return ((double)value) * 4.0;
                }
                public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
                {
                    throw new NotImplementedException();
                }
            }
        }
