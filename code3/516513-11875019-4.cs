    class A<T>
    {
        static readonly string Empty;
    
        static A() { }
     
        public A()
        {
            string.Format("{0}", Empty);
        }
    }
