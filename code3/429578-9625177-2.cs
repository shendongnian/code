    public class TaskQueue
    {
        protected Task Pending;
        public bool Ready { get { return Pending == null || Pending.IsCompleted || Pending.IsCanceled || Pending.IsFaulted; } }
        public Task Enqueue(Action work)
        {
            lock (this)
                return Pending = Ready ? Task.Factory.StartNew(work) : Pending.ContinueWith(_ => work());
        }
    }
