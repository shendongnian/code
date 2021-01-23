    class Program
        {
            static void Main(string[] args)
            {
                A a = new B();
                
                // Get the casted object.
                string fullName = a.GetType().FullName;
                object castedObject = Convert.ChangeType(a, Type.GetType(fullName));
    
                // Use reflection to get the type.
                var pi = castedObject.GetType().GetProperty("Visible");
    
                Console.WriteLine(a.Visible);
                Console.WriteLine((bool)pi.GetValue(castedObject, null));
    
                Console.Read();
            }
        }    
    
        class A
        {
            public bool Visible { get { return false; } }
        }
    
        class B : A
        {
            public new bool Visible { get { return true; } }
        }
    }
