     // program.cs file
     static class Program
        {
            static void Main(string[] args)
            {
                using (Game1 game = new Game1())
                {
                    game.Run();
                }
            }
        }
 
     // Game1.cs file
     public class Game1 : Microsoft.Xna.Framework.Game {
        GraphicsDeviceManager graphics;
      
        public Game1( ) {
            graphics = new GraphicsDeviceManager( this );
            Content.RootDirectory = "Content";
        }
        ....
     }
