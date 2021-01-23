    public class ResourceManager : System.Resources.ResourceManager
    {
        public ResourceManager(Type resourceSource)
            : base(resourceSource)
        {
        }
    
        public IEnumerable<string> GetStringsByPrefix(string prefix)
        {
            return GetStringsByPrefix(prefix, null);
        }
        public IEnumerable<string> GetStringsByPrefix(string prefix, CultureInfo culture)
        {
            if (prefix == null)
                throw new ArgumentNullException("prefix");
            if (culture == null)
                culture = CultureInfo.CurrentUICulture;
            var resourceSet = this.InternalGetResourceSet(culture, true, true);
            IDictionaryEnumerator enumerator = resourceSet.GetEnumerator();
            List<string> results = new List<string>();
            while (enumerator.MoveNext())
            {
                string key = (string)enumerator.Key;
                if (key.StartsWith(prefix))
                {
                    results.Add((string)enumerator.Value);
                }
            }
            return results;
        }
    } 
