    public class Game1 : Microsoft.Xna.Framework.Game
    {
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;
    Dictionary<int, Player> players;
    Texture2D texture;
    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
    }
    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        texture = Content.Load<Texture2D>("player");
        Random rnd = new Random();
        players = new Dictionary<int, Player>()
            {
                // Add 5 new players, their location is random and so is their rotation.
                {0,  new Player() { Position = new Vector2(rnd.Next(1024),rnd.Next(768)), Rotation = rnd.Next(360), Size = new Vector2(texture.Width, texture.Height)}}, 
                {1,  new Player() { Position = new Vector2(rnd.Next(1024),rnd.Next(768)), Rotation = rnd.Next(360), Size = new Vector2(texture.Width, texture.Height)}}, 
                {2,  new Player() { Position = new Vector2(rnd.Next(1024),rnd.Next(768)), Rotation = rnd.Next(360), Size = new Vector2(texture.Width, texture.Height)}}, 
                {3,  new Player() { Position = new Vector2(rnd.Next(1024),rnd.Next(768)), Rotation = rnd.Next(360), Size = new Vector2(texture.Width, texture.Height)}}, 
                {4,  new Player() { Position = new Vector2(rnd.Next(1024),rnd.Next(768)), Rotation = rnd.Next(360), Size = new Vector2(texture.Width, texture.Height)}}, 
            };
    }
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        spriteBatch.Begin();
        for (int i = 0; i < players.Count; i++)
        {
            Player targetPlayer = players[i];
            spriteBatch.Draw(texture, targetPlayer.PlayerRectangle, null, Color.White, targetPlayer.Rotation, targetPlayer.Centre, SpriteEffects.None, 0.0f);
        }
        spriteBatch.End();
        base.Draw(gameTime);
    }
    }
    class Player
    {
    Rectangle playerRectangle;
    Vector2 position;
    Vector2 size;
    Vector2 center;
    public Vector2 Position { get { return position; } set { position = value; UpdateRectangleAndCentre(); } }
    public Vector2 Size { get { return size; } set { size = value; UpdateRectangleAndCentre(); } }
    public float Rotation { get; set; }
    public Rectangle PlayerRectangle { get { return playerRectangle; } }
    public Vector2 Centre { get { return center; } }
    void UpdateRectangleAndCentre()
    {
        playerRectangle = new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
        center = new Vector2(size.X / 2, size.Y / 2);
    }
    }
