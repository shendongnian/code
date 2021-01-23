    [ProtoContract]
    class Foo
    {
        [ProtoMember(1)]
        public int X { get; set; }
        [ProtoMember(2)]
        public string Y { get; set; }
    
    }
    [ProtoContract]
    class MyData
    {
        private readonly List<Foo> items = new List<Foo>();
        [ProtoMember(1)]
        public List<Foo> Items { get { return items; } }
    }
