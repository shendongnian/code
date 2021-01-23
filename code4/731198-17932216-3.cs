    public class MainViewModel : ViewModelBase
    {
        public ICommand ClickCommand { get; set; }
        private readonly IStatusBarViewModel _statusBarViewModel;
        public MainViewModel(IStatusBarViewModel statusBarViewModel)
        {
            _statusBarViewModel = statusBarViewModel;
            ClickCommand = new RelayCommand(ExecuteClickCommand, CanExecuteClickCommand);
        }
        private void ExecuteClickCommand(object obj)
        {
            _statusBarViewModel.StatusBarText = "Updating the db";
        }
        private bool CanExecuteClickCommand(object obj)
        {
            return true;
        }
        public void DoSomethingVeryImportant()
        {
            _statusBarViewModel.StatusBarText = "Starting some work";
            // do some work here
            _statusBarViewModel.StatusBarText = "Done doing some work";
        }
    }
