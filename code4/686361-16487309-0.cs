    public class GameModel
    {
        string displayDate = "Eschaton 23, 3834.4 (default value for illustration, never actually used)";
    
        public GameModel()
        {
            // Initialize to 0 and then increment immediately. This is a hack to start on turn 1 and to have the game
            // date be initialized to day 1.
            incrementableDayNumber = 0;
            IncrementDate();
        }
    
        public void PretendToLoadAGame(string gameDate)
        {
            DisplayDate = gameDate;
            incrementableDayNumber = 1;
        }
    
        public string DisplayDate
        {
            get { return displayDate; }
            set
            {
                // set the internal value
                displayDate = value;
    
                // notify the View of the change in Date
                if (DateChanged != null)
                    DateChanged(this, EventArgs.Empty);
            }
        }
    
        public event EventHandler DateChanged;
    
        // use similar techniques to handle other properties, like 
    
    
        int incrementableDayNumber;
        public void IncrementDate()
        {
            incrementableDayNumber++;
            DisplayDate = "Eschaton " + incrementableDayNumber + ", 9994.9 (from turn end)";
        }
    }
