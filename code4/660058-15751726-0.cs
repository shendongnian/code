    class InternalBusService<T>
        where T : SomeType
    {
        public InternalBusService(IEnumerable<Action<T>> subscriptions)
        {
            foreach (var subscription in subscriptions)
            {
                this.bus.Subscribe<T>(subscription);
            }
        }
    }
