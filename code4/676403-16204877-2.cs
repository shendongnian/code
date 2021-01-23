    public void DrawAsteroid(float x, float y)
            {
                vAsteroid.X -= 5; vAsteroid.Y = y;
                spriteBatch.Begin();
                spriteBatch.Draw(Game1.tAsteroid, vAsteroid, Color.White);
                spriteBatch.End();
            }
