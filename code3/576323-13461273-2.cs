    public class Upper : IUpper, ILowerToUpperCallback
    {
       public Upper(/* all depedencies except ILower */) { }
    
        // Promote ILower to property dependency
        public ILower Lower { get; set; }
    }
    public class Lower : ILower
    {
        // Use the Null Object Pattern for default implementation to prevent
        // null checks.
        private ILowerToUpperCallback callback = new NullCallback();
        public Upper(/* all dependencies except ILowerToUpperCallback */)
        {
            this.callback = callback;
        }
        // Allow overriding the default implementation using a method, just
        // as you are already did.
        public SetCallback(ILowerToUpperCallback callback)
        {
            if (callback == null) throw new ArgumentNullException("callback");
            this.callback = callback;
        }
    }
