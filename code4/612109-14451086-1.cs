    public class Configs
    {
        // Reference to the main game class.
        private Game _game;
    
        public Configs(Game game)
        {
           // Store the game reference to a local variable.
            _game = game;
        }
    
        public void SetMouseVisible()
        {
            // This is a reference to you main game class that was 
            // passed to the Configs class constructor.
            _game.IsMouseVisible = true;
        }
    }
