    static void Main()
            {
                A a = new A();
                a.FieldA = 999; // change the object
                a.test(); // "This is A and FieldA is 999"
    
                //B b = (B)a; // => Error: Invalid you cannot downcast !
    
                // using reflection we turn "a" into an instance of B that is a copy of the old "a"
                a = new B(a);
                a.test(); // This will call the method in B: "Calling the new method"  "This is B and FieldA is 999 and FieldB is 10"
    
                // a.newMethod(); => Error cannot access this method because "a" is declared as an instance of A (even though it's actually of B now)
    
                B b = (B)a; // Now downcasting works fine (because A is an instance of B actually)
    
                b.newMethod(); // works as expected: "This is B and FieldA is 999 and FieldB is 10"
            }
    
    
    
            class A
            {
                public int FieldA;
    
                public A()
                {
                    FieldA = 100;
                }
    
                virtual public void test()
                {
                    Console.WriteLine("This is A and FieldA is {0}", FieldA);
                }
            }
    
            class B : A
            {
                int FieldB;
                public B(A a)
                {
                    // copy all fields
                    foreach (FieldInfo pi in typeof(A).GetFields())
                        GetType().GetField(pi.Name).SetValue
                           (this, pi.GetValue(a));
    
                    // add this field:
                    FieldB = 10;
                }
    
                // We can override methods
                override public void test()
                {
                    Console.WriteLine("Calling the new method:");
                    newMethod();
                }
    
                // Add a new method but it will only be visible after casting A to B
                public void newMethod()
                {
                    Console.WriteLine("This is B, FieldA is {0} and FieldB is {1}", FieldA, FieldB);
                }
            }
