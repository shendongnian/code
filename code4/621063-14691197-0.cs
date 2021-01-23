    public class Step<T>
    {
        Action _action;
    
        public Step(Action action)
        {
            Contract.Requires(action != null);
    
            _action = action;
        }
    
        public void PerformStep()
        {
            _action.Invoke();
        }
    }
