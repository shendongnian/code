        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 4; i++)
            {
                RadioButton rb = new RadioButton() { Content = "Radio button " + i, IsChecked = i == 0  };
                rb.Checked += (sender, args) => { /* Do stuff */ };
                rb.Unchecked += (sender, args) => { /* Do stuff */ };
                MyStackPanel.Children.Add( rb );
            }
        }
