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
            public int Field 
            { 
                get { return field; }
                set { field = value; }
            }
            
            //If you don't need special logic, you can use an auto property
            //instead of using a backing field.
            public int SomeProperty {get; set;}
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
