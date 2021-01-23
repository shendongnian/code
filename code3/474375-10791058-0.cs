    public class GameStateManager
    {
        private static GameStateManager _instance = new GameStateManager();
    
        public static GameStateManager Instance { get { return _instance; } }
    
        public BaseState Current { get; private set; }
        public GameStateManager()
        {
             Current = new InGame();
        }
    
        public void ChangeState(GameState state, GameTime gameTime)
        {
             // change your current state here, I'm not really sure about your logic here
             Current.UpdateState(gameTime);
             switch(state)
             {
                case GameState.Menu:
                  Current = new MainMenu();
                // etc.
                default:
                   throw new NotImplementedException(string.Formatted("The state {0} is not implemented.", state));
             }
        }
    }
