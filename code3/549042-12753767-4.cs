    public class Human
    {       
        // Virtual method 
        public virtual void Say()
        {
            Console.WriteLine("i am a human");
        }
    }
    public class Male: Human
    {        
        // Override the virtual method 
        public override void Say()
        {
            Console.WriteLine("i am a male");
            base.Draw(); // --> This will access the Say() method from the 
           //parent class.           
        }
    }
