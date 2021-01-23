    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            TestClassAccess test = new TestClassAccess();
            TestClassAccess._hasAccess = false;
            test.MyPropInt = 4;
            test.MyPropString = "TEST";
            Console.WriteLine("MyPropInt {0}, MyPropString '{1}'",test.MyPropInt, test.MyPropString);
            // Prints "MyPropInt -1, MyPropString ''
        }
        class TestClassAccess
        {
            private int myPropInt = 0;
            public int MyPropInt { get { return myPropInt; } set { myPropInt = ModifyOnAccessDenied<int>(value); } }
            private string myPropString = string.Empty;
            public string MyPropString { get { return myPropString; } set { myPropString = ModifyOnAccessDenied<string>(value); } }
            public static volatile bool _hasAccess = false;
            private T ModifyOnAccessDenied<T>(T propertyToChange)
            {
                if (!_hasAccess)
                {
                    if (propertyToChange is string)
                        return (dynamic)string.Empty;
                    else if (propertyToChange is int)
                        return (dynamic)(int)-1;
                }
                return propertyToChange;
            }
        }
      
