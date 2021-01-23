    public Vector2 BallPosition
    {
        get
        {
            return ballPosition;
        }
        set
        {
            ballRectangle.X = value.X;
            ballRectangle.Y = value.Y;
            ballPosition = value;
        }
    }
    private Vector2 ballPosition
