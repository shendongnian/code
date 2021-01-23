    //assuming you're using GameTime gameTime for the timing values
    Position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
    //increment total distance indepedent of direction/axis
    distance += Math.Abs(velocity.X) + Math.Abs(velocity.Y);
    //test if we've travelled far enough
    if (distance >= tileSize)
    {
        //reset distance
        distance = 0.0f;
        //stop
        velocity = Vector2.Zero;
        //TODO: SNAP TO TILE
    }
