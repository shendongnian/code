    public class MyList<T, E> : IList<T>, IReadOnlyList<T>
        where T : MyRecordClass
    {
    }
    public class MyOtherClass
    {
        public void MyMethod(IReadOnlyList<MyRecordClass> list) { }
    }
