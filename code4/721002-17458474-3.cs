    public abstract class ScreenViewModel : ViewModelBase // Implements INotifyPropertyChanged
    {
        private Player _currentPlayer;
        
        public ScreenViewModel(IRepository<Player> playerRepository)
        {
            // Retrieve desired player from the repository.
            this._currentPlayer = playerRepository.Find(...);
        }
        // This is an idea of the sort of thing you can do; derived viewModels
        // do not need to worry about loading the player, they can just consume
        // it and provide the screen specific behaviour.
        protected Player CurrentPlayer
        {
            get { return _currentPlayer; }
        }
    }
