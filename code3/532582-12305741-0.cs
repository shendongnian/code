    class A
    {
        static A()
        {
            //buggy code here
        }
        static SomeField f = new ThisClassThrowsWhenConstructed(); // <-- or here
    }
