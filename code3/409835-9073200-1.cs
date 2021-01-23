    using System;
    namespace Test
    {
        abstract class  Base
        {
            public string Data;
        }
        class Derived : Base
        {
            // this is a separate field, has nothing in common with the base class field but name
            new public string Data;
        }
        class Program
        {
            static void Main(string[] args)
            {
                Derived test = new Derived();
                //Let's set the Data field in the derived class
                test.Data = "Derived";
            
                //Now let's set this field in the base class
                Base cast = test;
                cast.Data = "Base";
                //We can see that the feild in the derived class has not changed
                //This will print 'Derived'
                Console.WriteLine(test.Data);
                // Just to make sure that a new object has not been constructed by a miracale
                // let's pass our object to a function that will display the Data field from
                // the base class
                Test(test);
            }
            static void Test(Derived test)
            {
                // When called from the Main above this will print 'Base'
                Console.WriteLine(((Base)test).Data);            
            }
        }
    }
