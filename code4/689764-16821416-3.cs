    public class Selector<T> : List<ISelectorNode<T>>
    {
        public static SelectorNode<T, TOut> Get<TOut>(Expression<Func<T, TOut>> selector)
        {
            return new SelectorNode<T, TOut>(selector);
        }
        public Selector<T> Add(params ISelectorNode<T>[] nodes)
        {
            AddRange(nodes);
            return this;
        }
    }
    public class SelectorNode<T, TOut> : List<ISelectorNode<TOut>>, ISelectorNode<T>
    {
        internal SelectorNode(Expression<Func<T, TOut>> selector)
        {
        }
        public ISelectorNode<T> Add(params ISelectorNode<TOut>[] nodes)
        {
            AddRange(nodes);
            return this;
        }
    }
