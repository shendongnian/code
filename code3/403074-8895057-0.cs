    void Main()
    {
       var a = new A();
       var message = a.GetAs();
    }
    public class A {
        
        private readonly string someAs;
        
        public A()
        {
            someAs = "AaaaaAAAAAaaAAAAAAAaa";
            return;
        }
    
        public String GetAs()
        {
            return someAs;
        }
    }
