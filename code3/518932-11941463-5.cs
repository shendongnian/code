    public partial class MainWindow : Window
    {
        MainWindowViewModel ViewModel { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MainWindowViewModel();
            ViewModel.ShowMessage += ViewModel_ShowMessage;
            this.DataContext = ViewModel;
        }
        void ViewModel_ShowMessage(object sender, ShowMessageEventArgs e)
        {
            MessageBox.Show(e.Message, "Some caption", MessageBoxButton.OK);
        }
    }
