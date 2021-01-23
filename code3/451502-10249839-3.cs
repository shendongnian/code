    class Program
        {
            private static readonly object _lockObject = new object();
            private static int _counter = 1;
    
            [PreventEventHookedTwice]
            public static event Action<string> GoodEvent;
            
            
            public static event Action<string> BadEvent;
            
            public static void Handler (string message)
            {
                lock(_lockObject)
                {
                    Console.WriteLine(_counter +": "+ message);
                    _counter++;
                }
            }
            
            static void Main(string[] args)
            {
                GoodEvent += Handler;
                GoodEvent += Handler;
                GoodEvent += Handler;
                GoodEvent += Handler;
                GoodEvent += Handler;
                Console.WriteLine("Firing Good Event. Good Event is subscribed 5 times from the same Handler.");
                GoodEvent("Good Event is Invoked.");
    
                _counter = 1;
                BadEvent += Handler;
                BadEvent += Handler;
                BadEvent += Handler;
                BadEvent += Handler;
                BadEvent += Handler;
                Console.WriteLine("Firing Bad Event. Bad Event is subscribed 5 times from the same Handler.");
                BadEvent("Bad Event is Invoked.");
    
                _counter = 1;
                GoodEvent -= Handler;
                Console.WriteLine("GoodEvent is unsubscribed just once. Now fire the Event");
                if(GoodEvent!= null)
                {
                    GoodEvent("Good Event Fired");
                }
                Console.WriteLine("Event is not received to Handler.");
    
                BadEvent -= Handler;
                Console.WriteLine("BadEvent is unsubscribed just once. Now fire the Event");
                BadEvent("Good Event Fired");
                Console.WriteLine("Event is fired 4 times. If u subscribe good event 5 times then u have to unscribe it for 5 times, otherwise u will be keep informed.");
    
                Console.ReadLine();
            }
        }
