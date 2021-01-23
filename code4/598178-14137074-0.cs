    public override void Update(GameTime gameTime)
        {
            Vector2 velocity = Body.LinearVelocity;
            float radians = (float)(Math.Atan2(-velocity.X, velocity.Y) + Math.PI/2.0);
            Body.Rotation = radians;
            base.Update(gameTime);
        }
