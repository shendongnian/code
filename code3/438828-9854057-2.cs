    public class BigRedBird : Bird
    {
        public BigRedBird( Game game, ... ) : base(game)
        {
            base.Velocity = ...;  // note: base. not strictly required
            ...
        }
    }
