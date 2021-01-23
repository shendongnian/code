    namespace My.Namespace
    {
        public class MyClassA
        {
            public void MyMethod()
            {
                // Use value from MyOtherClass
                int myValue = My.Some.Namespace.MyClassB.MyInt;
            }
        }
    }
    
    namespace My.Some.Namespace
    {
        public class MyClassB
        {
            private static int myInt;
            public static int MyInt
            {
                get {return myInt;}
                set {myInt = value;}
            }
            // Can also do this in C#3.0
            public static int MyOtherInt {get;set;}
        }
    }
