    public bool RFull_Checked
        {
            get { return (bool)GetValue(RFull_CheckedProperty); }
            set { SetValue(RFull_CheckedProperty, value); }
        }
        // Using a DependencyProperty as the backing store for RFull_Checked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RFull_CheckedProperty =
            DependencyProperty.Register("RFull_Checked", typeof(bool), typeof(MainWindow), new PropertyMetadata(false));
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        string _name = "bla";
        private void Window_Initialized(object sender, EventArgs e)
        {
            if (_name.Length != 0)
            {
               RFull_Checked = true;
            }
        }
