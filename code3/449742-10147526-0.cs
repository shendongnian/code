    public sealed class myClass
    {
        private static readonly Lazy<myClass> lazyInstance = 
            new Lazy<myClass>(() => new myClass());
        public static Instance
        {
            get
            {
                return lazyInstance.Value;
            }
        }
        private myClass()
        {
            // constructor logic here
        }
    }
