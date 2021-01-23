In the type that declares the event, you can use GetInvocationList() to find out which delegates are subscribed:
    public class EventProvider
    {
        public event EventHandler SomeEvent;
        
        protected virtual void OnSomeEvent(EventArgs args)
        {
            if (SomeEvent != null)
            {
                var delegates = SomeEvent.GetInvocationList();
                foreach (var del in delegates)
                {
                    Console.WriteLine("{0} has subscribed to SomeEvent", del.Method.Name);
                }
                SomeEvent(this, args);
            }
        }
        public void RaiseSomeEvent()
        {
            OnSomeEvent(EventArgs.Empty);
        }
    }
    public class Program
    {
        public static void Main()
        {
            EventProvider provider = new EventProvider();
            provider.SomeEvent += Callback1;
            provider.SomeEvent += Callback2;
            provider.RaiseSomeEvent();
        }
        public static void Callback1(object sender, EventArgs e)
        {
            Console.WriteLine("Callback 1!");
        }
        public static void Callback2(object sender, EventArgs e)
        {
            Console.WriteLine("Callback 2!");
        }
    }
