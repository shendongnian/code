    public abstract class GameStateBehaviour
    {
        public event EventHandler<GameStateEvents> StateChanged;
        protected GameStateBehaviour()
        {
            StateChanged += (sender, events) => FunctionCalledWhenStateChanges();
        }
        public virtual void FunctionCalledWhenStateChanges()
        {
            // The called function
        }
        protected void OnStateChanged(GameStateEvents e)
        {
            if (StateChanged != null) StateChanged(this, e);
        }
    }
