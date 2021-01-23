    ObservableCollection<string> list = new ObservableCollection<string>();
        public Window()
        {
            InitializeComponent();
            datagrid1.ItemsSource = list;
           
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            list.Add(textBox1.Text);
        }
