    public class CompositeSubscriber<T> : ISubscriber<T>
    {
        private IEnumerable<ISubscriber<T>> subscribers;
        public CompositeSubscriber(
            IEnumerable<ISubstriber<T>> subscribers)
        {
            this.subscribers = subscribers;
        }
        public void Handle(T value)
        {
            foreach (var subscriber in this.subscribers)
            {
                subscriber.Handle(value);
            }
        }
    }
