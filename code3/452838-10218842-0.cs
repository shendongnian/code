    public virtual class Player
    {
        protected int MoveSpeed { get { return 2; } }
    }
    public class Player : Fighter
    {
        protected override int MoveSpeed { get { return 3; } }
    }
