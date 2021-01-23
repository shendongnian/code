    public class Foo
    {
        private HashSet<Action> callbacks = new HashSet<Action>();
        public event Action MyEvent
        {
            add
            {
                callbacks.Add(value);
            }
            remove
            {
                callbacks.Remove(value);
            }
        }
        private void FireMyEvent()
        {
            foreach (var action in callbacks)
            {
                ThreadPool.QueueUserWorkItem(o => { action(); });
            }
        }
    }
