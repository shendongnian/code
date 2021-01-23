    class MyType
    {
        private Foo bar = new Foo();
        [Editor(typeof(FooEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Foo Bar
        {
            get { return bar; }
            set { bar = value; }
        }
    }
