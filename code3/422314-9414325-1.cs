    public override void Update(GameTime gameTime)
    {
        direction = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));
        position += direction * speed * gameTime.ElapsedGameTime.Milliseconds;
    }
