    public class QueueItem
    {
        public Boolean IsRemoved { get; private set; }
        public void Remove() { IsRemoved = true; }
    }
