    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D enemy;
        Vector2 position, endposition;
        bool next_position = false;
        int count_nextposition;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
        }
        protected override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            enemy = Content.Load<Texture2D>("zombie");
            Random randomstart = new Random();
            position = new Vector2(randomstart.Next(100, 200), randomstart.Next(100, 200));
            endposition = new Vector2(randomstart.Next(100, 600), randomstart.Next(100, 400));
            count_nextposition = randomstart.Next(90, 121);
        }
        protected override void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            count_nextposition -= 1;
            Random random = new Random();
            position.X += 5 * delta;
            position.Y += 3 * delta;
            if (count_nextposition <= 0)
            {
            if (next_position == true)
            {
                endposition = new Vector2(random.Next(100, 600), random.Next(100, 400));
                next_position = false;
            }
            float max_distance = 100f * delta;
            if ((position - endposition).LengthSquared() > max_distance * max_distance)
            {
               Vector2 enemyDirection = Vector2.Normalize(endposition - position) * 100f;
               position += enemyDirection * delta;
            }
            else
            {
                
                next_position = true;
                count_nextposition = random.Next(90, 121);
            }
            }
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(enemy, position, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
