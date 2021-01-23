    class Foo
    {
        public string Name1 { get; set; }
        public string Name2 { get; private set; }
        public string Name3 { get { return Name2; } set { Name2 = value; }
    }
