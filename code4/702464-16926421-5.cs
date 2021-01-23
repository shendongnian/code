    class Leaf<TParam, TResult> : INode<TParam, TResult>
    {
        private TResult value;
        public Leaf(TResult value)
        {
            this.value = value;
        }
        public TResult GetValue(TParam[] parameters, int depth)
        {
            return value;
        }
    }
