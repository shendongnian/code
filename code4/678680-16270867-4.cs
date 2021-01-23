    public partial class ActionsListBoxSample : Window
    {
        public ActionsViewModel ViewModel { get; set; }
        public ActionsListBoxSample()
        {
            InitializeComponent();
            DataContext = ViewModel = new ActionsViewModel();
        }
         private void AddAction(object sender, RoutedEventArgs e)
        {
            ViewModel.AddAction();
        }
        private void DeleteAction(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteAction();
        }
        private void Run(object sender, RoutedEventArgs e)
        {
            ViewModel.Run();
        }
    }
