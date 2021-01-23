    public partial class MainWindow : Window
    {
        ObservableCollection<ListObject> _listDatasource;
        public MainWindow()
        {
            InitializeComponent();
            _listDatasource = new ObservableCollection<ListObject>();
            listView1.ItemsSource = _listDatasource;
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            AddWindow winAdd = new AddWindow();
            winAdd.AddItem += new AddItemHandler(winAdd_AddItem);
            winAdd.Show();
        }
        void winAdd_AddItem(object sender, ListObject itemToAdd)
        {
            _listDatasource.Add(itemToAdd);
        }
    }
