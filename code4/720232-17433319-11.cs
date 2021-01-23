     public MainWindow()
        {
            InitializeComponent();
            listBox.Items.Add(new CustomListBoxItem { Content = "hello world!" });
            listBox.Items.Add(new CustomListBoxItem { Content = "wpf is cool" });
            listBox.Items.Add(new CustomListBoxItem { Content = "today is tuesday..." });
            listBox.Items.Add(new CustomListBoxItem { Content = "I like coffee" });
        }
