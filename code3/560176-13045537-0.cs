    class Foo
    {
        private readonly Lazy<SomeType> _member = 
                                       new Lazy<SomeType>(() => new SomeType());
        public SomeType Member
        {
            get { return _member.Value; }
        }
    }
