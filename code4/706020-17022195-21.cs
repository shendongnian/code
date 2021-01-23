    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var view = new AView();
            var viewModel = new AViewModel();
            view.DataContext = viewModel;
            ViewPlaceholder.Children.Clear();
            ViewPlaceholder.Children.Add(view);
        }
    }
