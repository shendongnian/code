    public MainWindow() {
        InitializeComponent();
        MenuItem item = new MenuItem { Header = "test" };
        item.Click += new RoutedEventHandler(item_Click);
        menu1.Items.Add(item);
    }
    public void item_Click(Object sender, RoutedEventArgs e) {
        MessageBox.Show("Hello!");
    }
