    public partial class Bird : Microsoft.Xna.Framework.GameComponent
    {
       public Bird( Game game ) : base(game)
       {
       }
       public Bird( Game game, Vector2 velocity, Vector2 position ) : base(game)
       {
           Velocity = velocity;
           ...
       }
    }
