    namespace HideBaseClassMethod
    {
        class Program
        {
            static void Main(string[] args)
            {
                Parent myParent = new Parent();
                //myParent. - no one of overloaded protected methods are accessible after dot operator
               Child myChild = new Child();
               myChild.Method(2.5, 4.3); //double 
               myChild.Method(2, 4);//int
               Parent myChildCreatedAsParent = new Child();
               //myChildCreatedAsParent.  - no one of overloaded protected methods are accessible after dot operator
            }
        }
        class Parent 
        {
            protected double Method(double a, double b)
            {
               Console.WriteLine($"I am a parent double method {a} + {b}");
               return a + b;
            }
            protected int Method(int a, int b)
           {
                Console.WriteLine($"I am a parent integer method {a} + {b}");
                return a + b;
           }
       }
       class Child:Parent
       {
            public new double Method(double a, double b)
            {
                Console.WriteLine($"I am a child double method {a} * {b}");
                return a * b;
            }
            public new int Method(int a, int b)
            {
                Console.WriteLine($"I am a child integer method {a} * {b}");
                return a + b;
            }
        }
    }
