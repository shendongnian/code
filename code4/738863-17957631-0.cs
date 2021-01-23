    public class Ball
    {
	private Vector2 _position;
	private Vector2 _velocity;
	private Point _bounds;
	public Vector2 Position { get { return _position; } set { _position = value; } }
	public Vector2 Velocity { get { return _velocity; } set { _velocity = value; } }
	public int LeftSide { get { return (int)_position.X - (_bounds.X / 2); } }
	public int RightSide { get { return (int)_position.X + (_bounds.X / 2); } }
	public Rectangle DrawDestination
	{
		get
		{
			return new Rectangle((int)_position.X, (int)_position.Y, _bounds.X, _bounds.Y);
		}
	}
	
	public Ball(Texture2D ballTexture)
	{
		_position = Vector2.Zero;
		_velocity = Vector2.Zero;
		_bounds = new Pointer(ballTexture.Width, ballTexture.Height);
	}
	
	public void MoveToCenter()
	{
		_position.X = 400.0f;
		_position.Y = 250.0f;
	}
	
	public void Update(GameTime gameTime)
	{
		_position += _velocity;
	}
    }
