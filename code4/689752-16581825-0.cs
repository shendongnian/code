    public class Selector<T> : List<ISelectorNode<T>>
    {
        public SelectorNode<T, TOut> Add<TOut>(Expression<Func<T, TOut>> select)
        {
            var node = new SelectorNode<T, TOut>(select);
            base.Add(node);
            return node;
        }
    }
    public class SelectorNode<T, TOut> : List<ISelectorNode<TOut>>, ISelectorNode<T>
    {
        public SelectorNode<TOut, S> Add<S>(Expression<Func<TOut, S>> select)
        {
            var node = new SelectorNode<TOut, S>(select);
            base.Add(node);
            return node;
        }
        public SelectorNode(Expression<Func<T, TOut>> select)
        {
        }
    }
