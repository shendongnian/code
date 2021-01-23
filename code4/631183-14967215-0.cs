    public class MessagePump
    {
        private BlockingCollection<Action> actions = new BlockingCollection<Action>();
        public void Run() //you may want to restrict this so that only one caller from one thread is running messages
        {
            foreach (var action in actions.GetConsumingEnumerable())
                action();
        }
        public void AddWork(Action action)
        {
            actions.Add(action);
        }
        public void Stop()
        {
            actions.CompleteAdding();
        }
    }
