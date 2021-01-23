    public class DisposeChain<T> : IDisposable where T : IDisposable
    {
        public T Item { get; private set; }
        private IDisposable _innerChain;
        public DisposeChain(T theItem)
        {
            this.Item = theItem;
            _innerChain = null;
        }
        public DisposeChain(T theItem, IDisposable inner)
        {
            this.Item = theItem;
            _innerChain = inner;
        }
        public DisposeChain<U> Next<U>(Func<T, U> getNext) where U : IDisposable
        {
            try
            {
                U nextItem = getNext(this.Item);
                DisposeChain<U> result = new DisposeChain<U>(nextItem, this);
                return result;
            }
            catch  //an exception occurred - abort construction and dispose everything!
            {
                this.Dispose()
                throw;
            }
        }
        public void Dispose()
        {
            Item.Dispose();
            if (_innerChain != null)
            {
                _innerChain.Dispose();
            }
        }
    }
