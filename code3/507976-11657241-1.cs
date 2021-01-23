    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Documents;
    
    namespace DataGridConverter
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                List<MyClass> _source = new List<MyClass>();
                for (int i = 0; i < 5; i++)
                {
                    _source.Add(new MyClass { val = 1, str = "test " + i });
                }
    
                _source[2].val = -1;
    
                grid.ItemsSource = _source;
            }
        }
    
        public class MyClass
        {
            public int val { get; set; }
            public string str { get; set; }
            const int alwaysSetValue = 10;
        }
    
        public class MyValConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return (int)value == -1 ? string.Empty : value;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
