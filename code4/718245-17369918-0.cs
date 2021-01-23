    public class A
    {
        public int n = 42;
        public int k = B.Foo();
        public A()
        {
        }
    }
    public class B
    {
        public static unsafe int Foo()
        {
            //get a pointer to the newly created instance of A 
            //through some trickery.  
            //Possibly put some distinctive field value in `A` to make it easier to find
            int i = 0;
            int* p = &i;
            //get p to point to n in the new instance of `A`
            return *p;
        }
    }
