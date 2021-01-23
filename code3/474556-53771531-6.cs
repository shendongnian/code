        class A
        {
            // Class variable or " static member variable"  are declared with 
            //the "static " keyword
            public static int i=20;
            public int j=10;         //Instance variable 
            public static string s1="static class variable"; //Class variable 
            public string s2="instance variable";        // instance variable 
        }
        class Program
        {
            static void Main(string[] args)
            {
                A obj1 = new A();
    
                // obj1 instance variables 
                Console.WriteLine("obj1 instance variables ");
                Console.WriteLine(A.i);
                Console.WriteLine(obj1.j);
                Console.WriteLine(obj1.s2);
                Console.WriteLine(A.s1);
    
                A obj2 = new A();
    
                // obj2 instance variables 
                Console.WriteLine("obj2 instance variables ");
                Console.WriteLine(A.i);
                Console.WriteLine(obj2.j);
                Console.WriteLine(obj2.s2);
                Console.WriteLine(A.s1);
    
                Console.ReadKey();
    
            }
    
    
        }
    }
