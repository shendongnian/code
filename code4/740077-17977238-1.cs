    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Collections;
    namespace stackoverflowTreeview
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                Data = new ArrayList() { false, 5 };
            
            }
            public static DependencyProperty dData = DependencyProperty.Register("Data",     typeof(ArrayList), typeof(MainWindow));
            public ArrayList Data
            {
                get { return (ArrayList)GetValue(dData); }
                set { SetValue(dData, value); }
            }
        }
        public class testConv : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter,     System.Globalization.CultureInfo culture)
            {
                try
                {
                    return value.GetType();
                }
                catch { return typeof(object); }
            }
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
        public class nodeCompare : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                try
                {
                    return values[0] == values[1];
                }
                catch { return false; }
            }
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
