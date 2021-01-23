    static class Selector
    {
        //just a mechanism to share code. inline yourself if this is too much abstraction
        internal static S Add<R, S, T, TOut>(R list, Expression<Func<T, TOut>> selector,
                                             Func<SelectorNode<T, TOut>, S> returner) where R : List<ISelectorNode<T>>
        {
            var node = new SelectorNode<T, TOut>(selector);
            list.Add(node);
            return returner(node);
        }
    }
    public class Selector<T> : List<ISelectorNode<T>>
    {
        public Selector<T> AddToConcatRest<TOut>(Expression<Func<T, TOut>> selector)
        {
            return Selector.Add(this, selector, node => this);
        }
        public SelectorNode<T, TOut> AddToAddToItsInner<TOut>(Expression<Func<T, TOut>> selector)
        {
            return Selector.Add(this, selector, node => node);
        }
    }
    public class SelectorNode<T, TOut> : List<ISelectorNode<TOut>>, ISelectorNode<T>
    {
        internal SelectorNode(Expression<Func<T, TOut>> selector)
        {
        }
        public SelectorNode<T, TOut> InnerAddToConcatRest<TNextOut>(Expression<Func<TOut, TNextOut>> selector)
        {
            return AddToConcatRest(selector);
        }
        public SelectorNode<TOut, TNextOut> InnerAddToAddToItsInnerAgain<TNextOut>(Expression<Func<TOut, TNextOut>> selector)
        {
            return AddToAddToItsInner(selector);
        }
		//or just 'Concat' ?
        public SelectorNode<T, TOut> AddToConcatRest<TNextOut>(Expression<Func<TOut, TNextOut>> selector)
        {
            return Selector.Add(this, selector, node => this);
        }
        public SelectorNode<TOut, TNextOut> AddToAddToItsInner<TNextOut>(Expression<Func<TOut, TNextOut>> selector)
        {
            return Selector.Add(this, selector, node => node);
        }
    }
