    public MainPage()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                label1.Content = "Button is hit";
                ChildWindow1 objchld = new ChildWindow1();
                objchld.label1.Content = "I am child window";
                objchld.Show();
            }
