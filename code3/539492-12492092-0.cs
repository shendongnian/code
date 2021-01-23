    public struct Item
    {
        private IDictionary<string, string> values = new Dictionary<string, string>();
        public IDictionary<string, string> Values
        {
            get
            {
                return this.values;
            }
        }
    }
