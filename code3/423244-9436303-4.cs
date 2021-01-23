    class MyWeirdCollection : IEnumerable
    {
        public void Add(int i) { /*...*/ }
        public void Add(string s) { /*...*/ }
        public void Add(int i, string s) { /*...*/ }
        //IEnumerable implementation omitted for brevity
    }
