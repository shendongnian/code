    public sealed partial class MainPage : Page
    {
        private readonly MainPageViewModel viewModel;
        public MainPage()
        {
            this.InitializeComponent();
            viewModel = new MainPageViewModel();
            viewModel.LoadData();
            this.DataContext = viewModel;   
        }
        private void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            viewModel.UpdatePerson();
        }
    }
