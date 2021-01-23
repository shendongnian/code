    public class ResourceManagerWrapper : ResourceManager
    {
        private Dictionary<string, string> local_ = new Dictionary<string,string>();
        private ResourceManager manager_;
        public ResourceManagerWrapper(ResourceManager manager)
        {
            this.manager_ = manager;
        }
        public override string GetString(string name)
        {
            string value;
            if(local_.TryGetValue(name, out value))
            {
                return value;
            }
            else
            {
                return manager_.GetString(name);
            }
        }
        public void SetString(string key, string value)
        {
            local_[key] = value;
        }
    }
            
