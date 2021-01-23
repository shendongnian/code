    class ChildViewModel : Screen, IHandle<SelectionChangedMessage>
    {
        public ChildViewModel() 
        {
            // Subscribe to the aggregator so we receive messages from it
            AggregatorProvider.Aggregator.Subscribe(this);
        }
        // When we receive a SelectionChangedMessage...
        public void Handle(SelectionChangedMessage message) 
        {
            // Do something with the new selection
        }
    }
