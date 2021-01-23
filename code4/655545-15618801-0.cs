    public interface IOwner {}
    public interface IState
    {
        void Enter(IOwner item);
    }
    public class ChaseState : IState
    {
        public void Enter(IOwner pl)
        {
            // ...
            //...
        }
    }
    public class Player :IOwner { }
    public class Something {
        IOwner owner = new Team();
        IState globalState = new ChaseState();
        IState currentState = new DefendState();
        public void Update()
        {
            if (globalState != null)
            {
                globalState.Enter(owner); 
            }
            else if (currentState != null)
            {
                currentState.Enter(owner);
            }
         }
    }
