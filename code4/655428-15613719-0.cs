    public abstract class State<T>
    {
        public virtual Enter(T item)
        {
            // an empty method
        }
    }
    
    public class PlayerState : State<Player>
    {
        public override Enter(Player pl)
        {
            // method implementation
        }
    }
    
    public class GoalkeeperState : State<Goalkeeper>
    {
        public override Enter(Goalkeeper gk)
        {
            // method implementation
        }
    }
