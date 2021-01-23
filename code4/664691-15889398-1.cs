    class DummySite : ISite
    {
        public IComponent Component
        {
            get { throw new NotImplementedException(); }
        }
        public IContainer Container
        {
            get { throw new NotImplementedException(); }
        }
        public bool DesignMode
        {
            get { throw new NotImplementedException(); }
        }
        public string Name
        {
            get
            {
                return "asd";  // HERE'S YOUR TEXT
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public object GetService(Type serviceType)
        {
            return null;
        }
    }
