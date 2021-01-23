    public class Entity 
    {
        private Lazy<Dictionary<string, string>> name = 
            new Lazy<Dictionary<string, string>>(
                () => new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase));
        
        public Dictionary<string, string> Name
        {
            get
            {
                return name.Value;
            }
        }
    }
