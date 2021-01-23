    class YourClass
    {
        object yourObject;
        void Method1()
        {
            yourObject = new object();
        }
        void Method2()
        {
            int x = yourObject.GetHashCode();
        }
    }
