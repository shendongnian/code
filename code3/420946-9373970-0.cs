    private float _seconds = 0;
    protected override void Draw(GameTime gameTime)
    {
        if (_seconds < 1)
        {
            _seconds += gameTime.ElapsedGameTime.TotalSeconds;
        }
        RotationMatrix = Matrix.CreateRotationX(MathHelper.PiOver2) *
             Matrix.CreateRotationY(0.4f * _seconds);
        base.Draw(gameTime);
    }
