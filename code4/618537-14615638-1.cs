      public partial class MainWindow : Window
        {
            private ObservableCollection<string> _myList = new ObservableCollection<string>();
    
            public MainWindow()
            {
                InitializeComponent();
                MyList.Add("a");
                MyList.Add("b");
                MyList.Add("c");
                MyList.Add("d");
            }
    
            public ObservableCollection<string> MyList
            {
                get { return _myList; }
                set { _myList = value; }
            }
    
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                MyList.Add((sender as Button).Tag.ToString());
            }
         }
