    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new[]
            {
                new ViewModel { Name = "John", IsSelected = true },
                new ViewModel { Name = "Mary" },
                new ViewModel { Name = "Pater" },
                new ViewModel { Name = "Jane" },
                new ViewModel { Name = "James" },
            };
        }
    }
