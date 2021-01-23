        public MainWindow()
        {
            InitializeComponent();
            //created a border above
            ListBoxItem item = new ListBoxItem();
            item.Tag = path;
            item.Content = myBorder;
            listBox.Items.Add(item);
            listBox.SelectionChanged += new SelectionChangedEventHandler(listBox_SelectionChanged);
        }
        void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string path = (listBox.SelectedItem as ListBoxItem).Tag as string;
        }
