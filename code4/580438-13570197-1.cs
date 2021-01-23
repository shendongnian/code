    public abstract class Player
    {
        // Changed to auto property to save some key strokes...
        protected Sport Sport { get; set;}
    }
    
    public RealPlayer : Player
    {
        public void Foo(Sport sport)
        {
            this.Sport = sport; // Valid
        }
    }
    
