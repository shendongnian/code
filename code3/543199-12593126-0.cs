    public class MyEvent : BaseEvent
    {
        public override void Dispatch(IEventHandler handler)
        {
            if(!handler is IMyFirstEventHandler )throw new ArgumentException("message").
            ((IMyFirstEventHandler )handler).OnMyEvent(this);
        }
    }
