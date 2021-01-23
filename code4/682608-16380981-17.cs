    namespace WpfApplication11
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
                Items.Add(new myData { Title = "Item1", mdTime = 1, mdTime2 =3 });
                Items.Add(new myData { Title = "Item2", mdTime = 6, mdTime2 = 50 });
                Items.Add(new myData { Title = "Item3", mdTime = 45, mdTime2 = 23 });
                Items.Add(new myData { Title = "Item4", mdTime = 3, mdTime2 = 1 });
                Items.Add(new myData { Title = "Item5", mdTime = 8, mdTime2 = 9 });
               
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
            public int mdTime2 { get; set; }
            public bool mdisValid { get; set; }
        }
    
        public class MaxConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (values[0] is ObservableCollection<myData> && values[1] is DataGridCell && values[2] is myData)
                {
                    var collection = (ObservableCollection<myData>)values[0];
                    var columnName = (values[1] as DataGridCell).Column.Header.ToString();
                    var data = values[2] as myData;
    
                    if (columnName.Equals("mdTime") && collection.Max(x => x.mdTime).Equals(data.mdTime))
                    {
                         return new SolidColorBrush(Colors.Red);
                    }
                    else if (columnName.Equals("mdTime2") && collection.Min(x => x.mdTime).Equals(data.mdTime))
                    {
                        return new SolidColorBrush(Colors.Blue);
                    }
                }
                return new SolidColorBrush(Colors.Black);
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
