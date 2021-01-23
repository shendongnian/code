    class Caller
    {
        private Func<string> factory;
    
        public Caller()
        {
            this.factory = null;
            var service = new Service(out this.factory);
    
            // !!! but here is factory still not assigned
            string results = this.factory();
        }
    }
    
    class Service
    {
        public Service(out Func<string> factory)
        {
            factory = () => Guid.NewGuid().ToString();
        }
    }
