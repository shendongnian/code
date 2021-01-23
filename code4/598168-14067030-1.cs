    using System;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    namespace StackOverflow
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
        public class IntToImageConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                ImageSource result = null;
                var intValue = (int)value;
                switch (intValue)
                {
                    case 0:
                        {
                            result = new BitmapImage(new Uri(@"your_path_to_image_0"));
                            break;
                        }
                    case 1:
                        {
                            result = new BitmapImage(new Uri(@"your_path_to_image_1"));
                            break;
                        }
                }
                return result;
            }
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
