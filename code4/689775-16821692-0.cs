    public class Selector<T> : List<ISelectorNode<T>>
    {
        public void Add(params Selector<T>[] selectors)
        {
            Add(this, selectors);
        }
        static void Add<TOut>(List<ISelectorNode<TOut>> nodes, Selector<TOut>[] selectors)
        {
            foreach (var selector in selectors)
                nodes.AddRange(selector);
            //or just, Array.ForEach(selectors, nodes.AddRange);
        }
        public void Add<TOut>(Expression<Func<T, TOut>> selector)
        {
            var node = new SelectorNode<T, TOut>(selector);
            Add(node);
        }
        //better to have a different name than 'Add' in cases of T == TOut collision - when classes 
        //have properties of its own type, eg Type.BaseType
        public Selector<T> InnerAdd<TOut>(params Selector<TOut>[] selectors)
        {
            foreach (SelectorNode<T, TOut> node in this)
                Add(node, selectors);
            //or just, ForEach(node => Add((SelectorNode<T, TOut>)node, selectors));
            return this;
        }
    }
    public class SelectorNode<T, TOut> : List<ISelectorNode<TOut>>, ISelectorNode<T>
    {
        internal SelectorNode(Expression<Func<T, TOut>> selector)
        {
        }
    }
