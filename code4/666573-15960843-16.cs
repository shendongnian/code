    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            this.LoadHomePage();
            // Hook up Commands to associated methods
            this.LoadHomePageCommand = new DelegateCommand(o => this.LoadHomePage());
            this.LoadSettingsPageCommand = new DelegateCommand(o => this.LoadSettingsPage());
        }
        public ICommand LoadHomePageCommand { get; private set; }
        public ICommand LoadSettingsPageCommand { get; private set; }
        // ViewModel that is currently bound to the ContentControl
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value; 
                this.OnPropertyChanged("CurrentViewModel");
            }
        }
        
        private void LoadHomePage()
        {
            CurrentViewModel = new HomePageViewModel(
                new HomePage() { PageTitle = "This is the Home Page."});
        }
        private void LoadSettingsPage()
        {
            CurrentViewModel = new SettingsPageViewModel(
                new SettingsPage(){PageTitle = "This is the Settings Page."});
        }
    }
