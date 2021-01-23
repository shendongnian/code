        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Background, Dispatcher);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        private int _selectedItem = 0;
        void timer_Tick(object sender, EventArgs e)
        {
            tabControl.SelectedItem = tabControl.Items[_selectedItem];
            _selectedItem = (_selectedItem + 1) % tabControl.Items.Count;
        }
