    class MyControl : UserControl
    {
        public MyControl()
        {
            InitializeComponent();
            this.DataContext = new MyViewModel();
        }
    }
