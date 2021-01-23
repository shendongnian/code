    class MyType
    {
        private string bar;
        [Editor(typeof(MyStringEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public string Bar
        {
            get { return bar; }
            set { bar = value; }
        }
    }
