    public class Intro : IState
    {
        private IState currentState;
        private Game1 exit;
        Texture2D introscreen;
    
        public void Load(ContentManager content)
        {
            introscreen = content.Load<Texture2D>("intro");
        }
    
        public void Update(GameTime gametime)
        {
            KeyboardState kbState = Keyboard.GetState();
            if (kbState.IsKeyDown(Keys.Space))
              currentState = new Menu();
            if (kbState.IsKeyDown(Keys.Escape))
                exit.Exit(); // ---- this object does not exist
        }
    
        public void Render(SpriteBatch batch)
        {
            batch.Draw(introscreen, new Rectangle(0, 0, 1280, 720), Color.White);
        }
    }
