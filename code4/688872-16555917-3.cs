        public MainWindow()
        {
            InitializeComponent();
            YourCollection = new List<Button>();
            //Dummy Data for Demo 
            YourCollection.Add(new Button() { Height = 25, Width = 25 });
            YourCollection.Add(new Button() { Height = 25, Width = 25 });
            this.DataContext = this;
        }
        public List<Button> YourCollection { get; set; }
