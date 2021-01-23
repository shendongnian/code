    class MyClass
    {
        private int imNotStatic;
        public static void Bar()
        {
            // This will give you your 'An object reference is required` compile 
            // error, since you are trying to call the instance method SomeMethod
            // from a static method, as there is no 'this' to call SomeMethod on.
            SomeMethod(5);
            // This will also give you that error, as you are calling SomeMethod as
            // if it were a static method.
            MyClass.SomeMethod(42);
            // Again, same error, there is no 'this' to read imNotStatic from.
            imNotStatic = -1;
        }
        public void SomeMethod(int x)
        {
            // Stuff
        }
    }
