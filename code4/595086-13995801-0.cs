    static class AggregatorProvider 
    {
        // The event aggregator
        public static EventAggregator Aggregator = new EventAggregator();
    }
    class ShellViewModel : Conductor<IScreen>
    {
        // When the combo box selection changes...
        public void SelectionChanged(object SomeValue) 
        {
            // Publish an event to all subscribers
            AggregatorProvider.Aggregator.Publish(new SelectionChangedMessage(SomeValue));
        }
    }
