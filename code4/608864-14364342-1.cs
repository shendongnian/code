    public class Foo
    {
        public delegate void FooEventHandler(object sender, EventArgs args);
        
        public event FooEventHandler FirstEvent = delegate {};    
        public event FooEventHandler SecondEvent = delegate {};    
        public event FooEventHandler ThirdEvent = delegate {};    
        
        public void DoIt()
        {
            FireOne();
            FireTwo();
            FireThree();
        }
        
        public void FireOne()
        {
            Console.WriteLine("Firing event 1...");
            Thread.Sleep(1000);
            FirstEvent(this, new EventArgs());
        }
        public void FireTwo()
        {
            Console.WriteLine("Firing event 2...");
            Thread.Sleep(1000);
            SecondEvent(this, new EventArgs());
        }
        public void FireThree()
        {
            Console.WriteLine("Firing event 3...");
            Thread.Sleep(1000);
            ThirdEvent(this, new EventArgs());
        }
    }
