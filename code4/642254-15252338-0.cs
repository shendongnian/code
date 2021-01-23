    public class GameViewModel
    {
        public GameViewModel(INavigationService ns) : base(ns) 
        { 
           //It would probably be good to initialize Players here to avoid null
        }
        public ScoreBoardViewModel ScoreBoard { get; private set; }
        
        public IObservableCollection<Player> Players {get;set;}
       
        protected void OnInitialize()
        {
            //If everything goes as expected, Players should be populated now.
            ScoreBoard = new ScoreBoard(Players);
        }
    }
