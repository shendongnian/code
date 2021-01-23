        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CreateCheckboxes();
        }
        private void CreateCheckboxes()
        {
            for (int i = 0; i <= 5; i++)
            {
                CheckBox c = new CheckBox();
                c.Name = "Check" + i.ToString();
                c.Checked += c_Checked;
                checkboxcontainer.Children.Add(c);
            }
        }
        private void c_Checked(object sender, RoutedEventArgs e)
        {
            foreach (var control in checkboxcontainer.Children)
            {
                if (control is CheckBox && control != sender)
                {
                    CheckBox cb = (CheckBox)control;
                    cb.IsChecked = false;
                }
            }
        }
