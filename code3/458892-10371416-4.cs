    class Man
    {
        Texture2D _texture;
        public Vector2 Position { get; set; }
        public int Width { get; set; } 
        public int Height { get; set; }
        public Rectangle PositionRectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
            }
        }
        
        public Man(Texture2D texture)
        {
            this._texture = texture;
            this.Width = texture.Width;
            this.Height = texture.Height;
        }
        ... //other man related logic!
    }
    class Player
    {
        Texture2D _texture;
        int _frameCount;
        int _currentFrame;
        //other frame related logic...
        public Vector2 Position { get; set; }
        public int Width { get; set; } 
        public int Height { get; set; }
        public Rectangle PositionRectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
            }
        }
        public Rectangle SourceRectangle
        {
            get
            {
                return new Rectangle(Width * _currentFrame, 0, Width, Height);
            }
        }
        
        public Player(Texture2D texture, int frameWidth, int frameCount)
        {
            this._texture = texture;
            this.Width = frameWidth;
            this.Height = texture.Height;
            this._frameCount = frameCount;
            this._currentFrame = 0;
            //etc...
        }
        ... //other player related logic! such as updating _currentFrame
        public Draw(SpriteBatch spriteBatch)
        {
             spriteBatch.Draw(_texture, PositionRectangle, SourceRectangle, Color.White);
        }
    }
