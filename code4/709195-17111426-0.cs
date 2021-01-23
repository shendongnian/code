        // Public parameterless constructor - needed for designer
        public SecondPage()
        {
            InitializeComponent();
        }
        // Constructor with parameter 
        public SecondPage(string parameter)
        {
            InitializeComponent();
            MyTextBox.Text = parameter;
        }
