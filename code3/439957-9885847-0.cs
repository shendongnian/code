    internal class ExtendedData : IExtendedData
    {
    
        private IData data;
        public ExtendedData(IData data)
        {
            this.data = data;
        }
    
        public int Property
        {
            get { return data.Property; }
            private set { data.Property = value; }
        }
    
        public int ExtendedProperty
        {
            get
            {
                return 2 * Property;
            }
        }    
    }
