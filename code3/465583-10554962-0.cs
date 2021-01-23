    public class ChildViewModelMessage {
        // Implementation here
    }
    public class ShellViewModel : IHandle<ChildViewModelMessage> {
        ...
        public void Handle(ChildViewModelMessage message) {
            // Handle here
        }
    }
    public class ChildViewModel {
        ...
        public IEventAggregator Events { get; set; }
        protected void HandleClose() {
            this.Events.Publish(new ChildViewModelMessage());
        }
