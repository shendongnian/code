    public class MyClass
    {
        public TGen MyMethod<TGen, T>(TGen myGenClass)
            where TGen : MyGenericClass<T>
            where T : class
        {
            return myGenClass;
        }
    }
