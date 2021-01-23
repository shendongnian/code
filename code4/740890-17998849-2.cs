    public class MainViewModel : IHandle<ChangeUIStateMessage>
    {
        public bool UILocked { get { // getter } set { // prop changed code/setter etc... } }
        public MainViewModel(IEventAggregator aggregator)
        {
            aggregator.Subscribe(this);
        }
        public void Handle(ChangeUIStateMessage message)
        {
            UILocked = message.UILocked;
        }
    }
