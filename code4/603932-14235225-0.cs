    public class Game1 : Microsoft.Xna.Framework.Game
    {
        SpriteFont font;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        DateTime nowDateTime;
        string nowString;
        public Game1()
        {
            nowDateTime = DateTime.Now;
            nowString = nowDateTime.ToString();
        }
    }
