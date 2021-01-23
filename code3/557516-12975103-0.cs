    class Program
    {
        static void Main(string[] args)
        {
           // new S.N(); does not work
            var n = new S().Create();
        }
    }
    class S
    {
        public interface IN
        {
            int MyProperty { get; set; }
        }
        class N : IN
        {
            public int MyProperty { get; set; }
            public N()
            {
            }
        }
        public IN Create()
        {
            return new N();
        }
    }
