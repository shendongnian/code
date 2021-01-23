    class Program
    {
        static void Main(string[] args)
        {
            var test = new GenericTest();
            test.MyGenericMethod(Guid.NewGuid());
        }
    }
    class GenericTest
    {
        public void MyGenericMethod<T>(T t)
            where T : IConvertible
        {
        }
    }
