    public virtual class Player
    {
        protected virtual int MoveSpeed { get { return 2; } }
    }
    public class Fighter : Player
    {
        protected override int MoveSpeed { get { return 3; } }
    }
