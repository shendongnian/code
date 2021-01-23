    ...
        protected override void Update(GameTime gameTime)
        {
            var halfMaxX = maxX / 2;
            var amplitude = halfMaxX; // how much it moves from side to side.
            var frequency = 10; // how fast it moves from side to side.
            x = halfMaxX + Math.Sin(gameTime.TotalGameTime.TotalSeconds * frequency) * amplitude;
        }
    ...
