    internal class MyObj
    {
        public MyObj(string head, IEnumerable<Foo> tail)
        {
            Head = head;
            Tail = tail;
        }
        public string Head { get; set; }
        public IEnumerable<Foo> Tail { get; set; }
    }
