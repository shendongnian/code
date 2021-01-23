    class YourClass
    {
        void Method1()
        {
            Method2(new object());
        }
        void Method2(object theObject)
        {
            int x = theObject.GetHashCode();
        }
    }
