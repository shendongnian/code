    public class MyList : List<MyClass>
    {
        public MyList(IEnumerable<MyClass> list)
            : base(list)
        {
        }
    }
