    /// <summary>
    /// Wraps the non-remote Foo class and makes it remotely accessible.
    /// </summary>
    public class FooWrapper : MarshalByRefObject, IFoo
    {
        private IFoo _innerFoo;
    
        public FooWrapper(IFoo innerFoo)
        {
            this._innerFoo = innerFoo;
        }
    
        public void Post(byte[] data)
        {
            this._innerFoo.Post(data);
        }
    }
