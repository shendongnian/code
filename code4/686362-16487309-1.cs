    public class GameController
    {
        private static GameController instance;
        public static GameController Instance
        {
            get
            {
                if (instance == null)
                    instance = new GameController();
                return instance;
            }
        }
        private GameController() 
        {
            Model = new GameModel();
        }
        public void LoadSavedGame(string file) 
        {
            // set all the state as saved from file. Since this could involve initialization
            // code that could be shared with LoadNewGame, for instance, you could move this logic
            // to a method on the model. Lots of options, as usual in software development.
            Model.PretendToLoadAGame("Eschaton 93, 9776.9 (Debug: LoadSavedGame)");
        }
        public void LoadNewGame() 
        {
            Model.PretendToLoadAGame("Eschaton 12, 9772.3 (Debug: LoadNewGame)");
        }
        public void SaveGame() 
        {
            // to do 
        }
        // Increment the date
        public void EndTurn()
        {
            Model.IncrementDate();
        }
        public GameModel Model
        {
            get;
            private set;
        }
    }
