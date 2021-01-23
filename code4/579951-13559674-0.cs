    public class MainWindowViewModel : DispatcherObject, INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            Matches = new ObservableCollection<MatchViewModel>();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<MatchViewModel> _matches;
        public ObservableCollection<MatchViewModel> Matches
        {
            get { return _matches; }
            set
            {
                _matches = value;
                OnPropertyChanged("Matches");
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    public class MatchViewModel : DispatcherObject, INotifyPropertyChanged
    {
        public MatchViewModel()
        {
            HomeTeam = new TeamViewModel();
            AwayTeam = new TeamViewModel();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private TeamViewModel _homeTeam;
        public TeamViewModel HomeTeam
        {
            get { return _homeTeam; }
            set
            {
                _homeTeam = value;
                OnPropertyChanged("HomeTeam");
            }
        }
        private TeamViewModel _awayTeam;
        public TeamViewModel AwayTeam
        {
            get { return _awayTeam; }
            set
            {
                _awayTeam = value;
                OnPropertyChanged("AwayTeam");
            }
        }
        public void PlayMatch()
        {
            for (int i = 0; i < 6; i++)
            {
                if (i % 2 == 0)
                    OnGoalScored(HomeTeam);
                else
                    OnGoalScored(AwayTeam);
                Thread.Sleep(1000);
            }
        }
        private void OnGoalScored(TeamViewModel team)
        {
            if (!team.Dispatcher.CheckAccess())
            {
                team.Dispatcher.Invoke((Action<TeamViewModel>)OnGoalScored, team);
            }
            else
            {
                team.Score++; // do other stuff here
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    public class TeamViewModel : DispatcherObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        private int _score;
        public int Score
        {
            get { return _score; }
            set
            {
                _score = value;
                OnPropertyChanged("Score");
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
