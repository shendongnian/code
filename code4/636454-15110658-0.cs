    public interface ISomeEvent
    {
        event Action<ISomeEvent, EventHandlerArgs> RaiseEvent;
    }
    public class SomeEvent : ISomeEvent
    {
        public event Action<ISomeEvent, EventHandlerArgs> RaiseEvent;
    }
    public class EventHandlerArgs : EventArgs
    {
        public bool IsDo { get; set; }
    }
    public class SimpleTellDontAsk : ISomeEvent
    {
        public SimpleTellDontAsk()
        {
            RaiseEvent = (s,e) => { };
        }                                
        public void doSomething(string text, EventHandlerArgs args)
        {
            Console.WriteLine("Email this message {0}", text);
            //sending message with email
            args.IsDo = true;
            RaiseEvent(this, args);
        }
        public event Action<ISomeEvent, EventHandlerArgs> RaiseEvent;
    }
