    public class Context
    {
        public Action<Context> State { get; internal set; }
        public Context(Action<Context> state)
        {
            State = state;
        }
        public void Run()
        {
            while (State != null)
            {
                State(this);
            }
        }
    }
