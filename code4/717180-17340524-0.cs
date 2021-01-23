     public Window2()
        {
            InitializeComponent();
            if (Items == null)
                Items = new ObservableCollection<double?>();
    
            for (int i = 0; i < 50; i++)
            {
                if (i % 5 == 0)
                    Items.Add(null);
                else
                    Items.Add(i);
            }
    
            this.DataContext = this;
        }
    
        public ObservableCollection<double?> Items { get; set; }
