    <#+
    class Activity : IEnumerable<Property>
    {
        private string name, wrapper;
        private List<Property> properties;
        public Activity(string name, string wrapper)
        {
            this.name = name;
            this.wrapper = wrapper;
            this.properties = new List<Property>();
        }
        public void Add(Property property)
        {
            this.properties.Add(property);
        }
        public IEnumerator<Property> GetEnumerator()
        {
            return this.properties.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    #>
