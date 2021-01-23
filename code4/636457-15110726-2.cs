    public class SimpleTellDontAsk : ISomeEvent
    {
        public void doSomething(string text)
        {
            Console.WriteLine("Email this message {0}", text);
            //sending message with email
            if (RaiseEvent != null) //Check if we have listeners
            {
                EventHandlerArgs args = new EventHandlerArgs();
                args.IsDo = true;
                RaiseEvent(this, args);
            }
        }
        public event EventHandler<EventHandlerArgs> RaiseEvent;
    }
