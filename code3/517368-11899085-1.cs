        public MainWindow()
        {
            InitializeComponent();
            DataContext = new[] 
            { 
                new ViewModel { Text = "SELECT * FROM Foo", IsSelected = true },
                new ViewModel { Text = "SELECT * FROM Bar" },
                new ViewModel { Text = "DROP TABLE Foo" },
                new ViewModel { Text = "DROP TABLE Bar" },
            };
        }
