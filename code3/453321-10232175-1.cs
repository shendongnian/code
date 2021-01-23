    public class MyClass
    {
        public TGen MyMethod<TGen>(TGen myGenClass)
            where TGen : MyGenericClass<DateTime>
        {
            return myGenClass;
        }
    }
