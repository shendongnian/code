        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ObservableCollection<Item>
            {
                new Item
                {
                    Name = "John",
                    SubItems = 
                    {
                        "Mary", "Peter", "James"
                    },
                },
                new Item
                {
                    Name = "Homer",
                    SubItems = 
                    {
                        "Lisa", "Bart", "Marge"
                    },
                }
            };
        }
