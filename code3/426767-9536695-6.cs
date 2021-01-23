    public class test
        {
            [LazyLoadGetter]
            public int MyProperty { get { return LongOperation(); } }
        }
