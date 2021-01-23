    namespace WpfApplication24
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private ObservableCollection<myData> _items = new ObservableCollection<myData>();
    
            public MainWindow()
            {
                InitializeComponent(); 
                Items.Add(new myData { Title = "Item1", mdTime = 1 });
                Items.Add(new myData { Title = "Item2", mdTime = 6 });
                Items.Add(new myData { Title = "Item3", mdTime = 45 });
                Items.Add(new myData { Title = "Item4", mdTime = 3 });
                Items.Add(new myData { Title = "Item5", mdTime = 8 });
            }
    
            public ObservableCollection<myData> Items
            {
                get { return _items; }
                set { _items = value; }
            }
        }
    
        public class myData
        {
            public string Title { get; set; }
            public int mdTime { get; set; }
            public bool mdisValid { get; set; }
        }
    
        public class MaxConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (values[0] is ObservableCollection<myData> && values[1] is int)
                {
                    var collection = (ObservableCollection<myData>)values[0];
                    var time = (int)values[1];
    
                    return collection.Max(x => x.mdTime).Equals(time)
                        ? new SolidColorBrush(Colors.Red)
                        : new SolidColorBrush(Colors.Black);
                }
                return new SolidColorBrush(Colors.Black);
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
