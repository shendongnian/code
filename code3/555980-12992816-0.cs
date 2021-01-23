    public delegate void ButtonEvent(Button sender);
    public class Button
    {
        public Vector2 Position { get; set; }
        public int Width
        {
            get
            {
                return _texture.Width;
            }
        }
        public int Height
        {
            get
            {
                return _texture.Height;
            }
        }
        public event ButtonEvent OnHover;
        public event ButtonEvent OnClick;
        public event ButtonEvent OnMouseEnter;
        public event ButtonEvent OnMouseLeave;
        Texture2D _texture;
        MouseState _previousState;
        public Button(Texture2D texture, Vector2 position)
        {
            _texture = texture;
            this.Position = position;
            _previousState = Mouse.GetState();
        }
        public Button(Texture2D texture) : this(texture, Vector2.Zero) { }
        public void Update(MouseState mouseState)
        {
            Rectangle buttonRect = new Rectangle((int)this.Position.X, (int)this.Position.Y, this.Width, this.Height);
            Point mousePoint = new Point(mouseState.X, mouseState.Y);
            Point previousPoint = new Point(_previousState.X, _previousState.Y);
            if (buttonRect.Contains(mousePoint))
            {
                if (OnHover != null)
                    OnHover(this);
                if (!buttonRect.Contains(previousPoint))
                    if (OnMouseEnter != null)
                        OnMouseEnter(this);
                if (_previousState.LeftButton == ButtonState.Released && mouseState.LeftButton == ButtonState.Pressed)
                    if (OnClick != null)
                        OnClick(this);
            }
            else if (buttonRect.Contains(previousPoint))
            {
                if (OnMouseLeave != null)
                    OnMouseLeave(this);
            }
            _previousState = mouseState;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //spritebatch has to be started! (.Begin() already called)
            spriteBatch.Draw(_texture, Position, Color.White);
        }
    }
