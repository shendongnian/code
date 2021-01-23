    public class Level
    {
         Vector2 CharacterPosition;
         public Level()
         {
         }
         public void Update(GameTime gameTime)
         {
               float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
               //Move the character
               ChactacterPosition.X += elapsed * speed;
         }
    }
