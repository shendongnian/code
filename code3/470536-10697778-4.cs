        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ObservableCollection<TreeNode>
            {
                new TreeNode { Name = "Root", IsSelected = true }
            };
        }
