                float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds; //If you havent already, get the elapsed time
                if (velocity.X != 0f)
                {
                    Position += velocity.X * Vector2.UnitX * elapsed;
                    HandleCollisions(CollisionDirection.Horizontal);
                }
                if (velocity.Y != 0f)
                {
                    Position += velocity.Y * Vector2.UnitY * elapsed;
                    HandleCollisions(CollisionDirection.Vertical);
                }
