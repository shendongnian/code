            class Base 
            {
                public void method() 
                {
                    Console.WriteLine("Base method");
                }
            }
            class Derived : Base 
            {
                public void method()
                {
                    Console.WriteLine("Derived method");
                }
            }
            class Program
            {
                static void Main(string[] args)
                {
                    Derived d;
                    
                    d = new Derived();
                    d.method();
    
                    d = new Base();
                    d.method();
                }
            }
        
    
