    class Service
    {
        public Service(Func<string> factory)
        {
            string result = factory();
        }
    }
