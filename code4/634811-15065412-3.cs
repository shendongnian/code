    public class PublicKeyMappings
    {
        Dictionary<string, string> _mappings = new Dictionary<string, string>();
        string _defaultKey;
        public PublicKeyMappings AddMapping(string cc, string publicKey)
        {
            _mappings.Add(cc, publicKey);
            return this;
        }
        public PublicKeyMappings SetDefaultKey(string publicKey)
        {
            _defaultKey = publicKey;
            return this;
        }
        public string GetPublicKeyFor(string cc)
        {
            if (!_mappings.ContainsKey(cc))
                return _defaultKey;
            return _mappings[cc];
        }
    }
