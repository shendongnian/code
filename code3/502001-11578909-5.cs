    class MainClass
    {
        public static Publisher Publisher;
    
        static void Main()
        {
            Publisher = new Publisher();
    
            Thread eventThread = new Thread(DoWork);
            eventThread.Start();
    
            Publisher.StartPublishing(); //Keep on firing events
        }
    
        static void DoWork()
        {
            var subscriber = new Subscriber();
            subscriber = null; 
            //Subscriber is referenced by publisher's SomeEvent only
            Thread.Sleep(200);
            //We have waited enough, we don't require the Publisher now
            Publisher = null;
            GC.Collect();
            //Even after GC.Collect, publisher is not collected even when we have set Publisher to null
            //This is because 'StartPublishing' method is under execution at this point of time
            //which means it is implicitly reachable from Main Thread's stack (through 'this' pointer)
            //This also means that subscriber remain alive
            //Even when we intended the Publisher to stop publishing, it will keep firing events due to somewhat 'hidden' reference to it from Main Thread!!!!
        }
    }
    
    internal class Publisher
    {
        public void StartPublishing()
        {
            Thread.Sleep(100);
            InvokeSomeEvent(null);
            Thread.Sleep(100);
            InvokeSomeEvent(null);
            Thread.Sleep(100);
            InvokeSomeEvent(null);
            Thread.Sleep(100);
            InvokeSomeEvent(null);
        }
    
        public event EventHandler SomeEvent;
    
        public void InvokeSomeEvent(object e)
        {
            EventHandler handler = SomeEvent;
            if (handler != null)
            {
                handler(this, null);
            }
        }
        ~Publisher()
        {
            Console.WriteLine("I am never Printed");
        }
    }
    
    internal class Subscriber
    {
        public Subscriber()
        {
            if(MainClass.Publisher != null)
            {
                MainClass.Publisher.SomeEvent += PublisherSomeEvent;
            }
        }
    
        void PublisherSomeEvent(object sender, EventArgs e)
        {
            if (MainClass.Publisher == null)
            {
                //How can null fire an event!!! Raise Exception
                throw new Exception("Booooooooommmm");
                //But notice 'sender' is not null
            }
        }
    }
