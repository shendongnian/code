    public class DelayQueue<T>
    {
        private List<DelayQueueItem<T>> items = new List<DelayQueueItem<T>>();
    
        public void Enqueue(T item)
        {
            Enqueue(item, TimeSpan.Zero);
        }
    
        public void Enqueue(T item, TimeSpan delay)
        {
            items.Add(new DelayQueueItem<T>()
            {
                Value = item,
                ReadyTime = DateTime.Now.Add(delay)
            });
        }
    
        public T Dequeue()
        {
            DateTime now = DateTime.Now;
            var item = items.FirstOrDefault(i => i.ReadyTime <= now);
            if (item != null)
            {
                items.Remove(item);
                return item.Value;
            }
    
            return default(T);
        }
    
        private class DelayQueueItem<T>
        {
            public T Value { get; set; }
            public DateTime ReadyTime { get; set; }
        }
    }
