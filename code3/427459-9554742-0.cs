    public class SomethingWithADictionary {
        private Dictionary<string, Instance> instances = 
            new Dictionary<string, Instance>();
        public Instance this[string key]
        {
            get
            {
                Instance instance;
                if (!instances.TryGetValue(key, out instance))
                {
                    // Custom logic here
                }
                return instance;
            }
            // You may not even want this...
            set { instances[key] = value; }
        }
    }
