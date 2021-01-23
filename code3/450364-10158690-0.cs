    namespace ConsoleApplication68
    {
        class Program
        {
            static void Main(string[] args)
            {
               for (int i = 0; i < 5; i++) 
               { 
                  Foo test = new Foo();
                  Console.WriteLine(test.name); 
               } 
            }
        }
    
        class Foo 
        { 
            private static int count = 0; 
            public string name; 
     
            public Foo() 
            { 
                int fooNum = ++count; 
                name = "Foo" + fooNum; 
            } 
        } 
    }
