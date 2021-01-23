    public class Selector<T> : List<ISelectorNode<T>>
    {
        public static SelectorNode<T, TOut> Get<TOut>(Expression<Func<T, TOut>> selector)
        {
            return new SelectorNode<T, TOut>(selector);
        }
        public void Add<TOut>(Expression<Func<T, TOut>> selector)
        {
            var node = new SelectorNode<T, TOut>(selector);
            Add(node);
        }
    }
    public class SelectorNode<T, TOut> : List<ISelectorNode<TOut>>, ISelectorNode<T>
    {
        public SelectorNode(Expression<Func<T, TOut>> selector)
        {
        }
        public ISelectorNode<T> Add(params Expression<Func<TOut, object>>[] selectors)
        {
            foreach (var selector in selectors)
                base.Add(new SelectorNode<TOut, object>(selector));
            return this;
        }
        public ISelectorNode<T> Add(params ISelectorNode<TOut>[] nodes)
        {
            AddRange(nodes);
            return this;
        }
    }
