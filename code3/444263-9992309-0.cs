    public abstract class BaseHandler<T> : IHandler, IHandler<T>
    {
        public abstract void Handle(T myObject);
    
        void IHandler.Handle(object myObject)
        {
            ((IHandler<T>)this).Handle((T) myObject);
        }
    }
