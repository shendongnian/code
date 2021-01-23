    public partial class MainWindow : Window
    {
        public class Test
        {
            public string P1 { get; set; }
            public string P2 { get; set; }
            public string P3 { get; set; }
        }
        public MainWindow()
        {
            InitializeComponent();
            
            var t = new List<Test>(new[] { 
                new Test{ P1="på,dsl", P2="234234", P3="asdasdasd"},
                new Test{ P1="asasaspå,dsl", P2="23sadasd asf afasdasdasd4234", P3="asdasdasd" }, 
                new Test{ P1="på,ds1231l", P2="234", P3="1ddsdasd" },
            });
            dgTest.ItemsSource = t;
        }
        private void dgTest_Loaded(object sender, RoutedEventArgs e)
        {
            //Make the columns use starsizing so their combined width
            //can't be bigger than the actual datagrid that contains them.
            foreach (var column in dgTest.Columns)
            {
                var starSize = column.ActualWidth / dgTest.ActualWidth;
                column.Width = new DataGridLength(starSize, DataGridLengthUnitType.Star);
            }
        }
    }
