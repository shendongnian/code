    public class GameOverScreen
    {
    private Texture2D texture;
    private Game1 game;
    private KeyboardState lastState;
 
    public GameOverScreen(Game1 game)
    {
        this.game = game;
        texture = game.Content.Load<Texture2D>("GameOverScreen");
        lastState = Keyboard.GetState();
    }
 
    public void Update()
    {
        KeyboardState keyboardState = Keyboard.GetState();
 
        if (keyboardState.IsKeyDown(Keys.Enter) && lastState.IsKeyUp(Keys.Enter))
        {
            game.StartGame();
        }
        else if (keyboardState.IsKeyDown(Keys.Escape) && lastState.IsKeyUp(Keys.Escape))
        {
            game.Exit();
        }
 
        lastState = keyboardState;
    }
 
    public void Draw(SpriteBatch spriteBatch)
    {
        if (texture != null)
            spriteBatch.Draw(texture, new Vector2(0f, 0f), Color.White);
    }
    }
