    public class MyType : ObservableCollection<MyClass>
    {
        public MyType()
            : base()
        { }
        public MyType(IEnumerable<MyClass> collection)
            : base(collection)
        { }
        public MyType(List<MyClass> list)
            : base(list)
        { }
    }
