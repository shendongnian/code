     public void DrawAsteroid(Asteroid a)
                {
                    spriteBatch.Begin();
                    spriteBatch.Draw(Game1.tAsteroid, a.Position, Color.White);
                    spriteBatch.End();
                }
