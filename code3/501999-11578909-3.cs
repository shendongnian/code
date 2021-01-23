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
            GC.Collect(0);
            subscriber = null; 
            //Now subscriber and Publisher are Gen 1
            //Also subscriber is referenced by publisher's SomeEvent only
            Thread.Sleep(200);
            Publisher = null;
            //Now Publisher is eligible for collection and by extension all the subscribers
            //But we are not sure when will they be collected
            //In fact since these are Gen1 they can take quite some time
            //In the meantime Publisher keep firing events even when it is not valid for our program!!!!
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
            }
        }
    }
