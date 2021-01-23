    public class SetupGameViewModel : Screen 
    {
        private readonly INavigationService _navigationService;
 
        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public IObservableCollection<Player> Players { get; set; }
        
        public void StartGame() 
        {
            _navigationService.NavigateToViewModel<GameViewModel>(Players);
        }
        ...
    }
    public class GameViewModel : Screen
    {   
        private IObservableCollection<Player> _parameter;
        public IObservableCollection<Player> Parameter
        {
            get { return _parameter; }
            set
            {
                if (value.Equals(_parameter)) return;
                _parameter = value;
                NotifyOfPropertyChange(() => Parameter);
            }
        }
        
        protected override void OnActivate()
        {
            // do something with the player list
            // ...
        }
        ...
    }
