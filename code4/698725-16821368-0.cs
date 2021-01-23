    using namespace1;
    using namespace2;
    
    namespace MyNamespace
    {
        public class MyClass
        {
            //Fields at the top. Private is optional as it is private by default.
            private int field;
            //Properties next
            //This actually replaces your Method properties in your example.
            public int Field { get;set; }
            
            //Constructor if needed. It is optional.
            public MyClass()
            {
            }
            //Methods next
            public void SomeMethod()
            {
               //Do something
            }
    
        }
    }
