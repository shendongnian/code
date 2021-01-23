    class Thing {
        public IEnumerable<someType> A { get; set; }
        public IEnumerable<someType> B { get; set; }
        public int C { get { return A.Count(); } }
    }
