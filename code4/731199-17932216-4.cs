    public class OtherViewModel : ViewModelBase
    {
        private readonly IStatusBarViewModel _statusBarViewModel;
        public OtherViewModel(IStatusBarViewModel statusBarViewModel)
        {
            _statusBarViewModel = statusBarViewModel;
        }
        public void UpdateTheDatabase()
        {
            _statusBarViewModel.StatusBarText = "Starting db update";
            // do some work here
            _statusBarViewModel.StatusBarText = "Db update complete";
        }        
    }
