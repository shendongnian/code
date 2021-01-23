    class MyClass
    {
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
        public static readonly IComparer<MyClass> NameComparer = new MyNameComparaer();
        private class MyNameComparaer : IComparer<MyClass>
        {
            public int Compare(MyClass x, MyClass y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }
        public static readonly IComparer<MyClass> DateComparer = new MyDateComparer();
        private class MyDateComparer : IComparer<MyClass>
        {
            public int Compare(MyClass x, MyClass y)
            {
                return x.CreationTime.CompareTo(y.CreationTime);
            }
        }
    }
