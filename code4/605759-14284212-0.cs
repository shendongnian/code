    class MultiKeyLookup<A, B, C> : IEnumerable<Tuple<A, B, C>>
    {
        private readonly ILookup<A, Tuple<B, C>> a;
        private readonly ILookup<B, Tuple<A, C>> b;
        private readonly ILookup<C, Tuple<A, B>> c;
        private readonly IEnumerable<Tuple<A, B, C>> order;
        public MultiKeyLookup(IEnumerable<Tuple<A, B, C>> source)
        {
            this.order = source.ToList();
            this.a = this.order.ToLookup(
                o => o.Item1, 
                o => new Tuple<B, C>(o.Item2, o.Item3));
            this.b = this.order.ToLookup(
                o => o.Item2, 
                o => new Tuple<A, C>(o.Item1, o.Item3));
            this.c = this.order.ToLookup(
                o => o.Item3, 
                o => new Tuple<A, B>(o.Item1, o.Item2));
        }
        public ILookup<A, Tuple<B, C>> Item1
        {
            get
            {
                return this.a
            }
        }
        public ILookup<B, Tuple<A, C>> Item2
        {
            get
            {
                return this.b
            }
        }
        public ILookup<C, Tuple<A, B>> Item3
        {
            get
            {
                return this.c
            }
        }
        public IEnumerator<Tuple<A, B, C>> GetEnumerator()
        {
            this.order.GetEnumerator();
        }
        public IEnumerator IEnumerable.GetEnumerator()
        {
            this.order.GetEnumerator();
        }
    }
