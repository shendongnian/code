    public class ParserFactory
    {
        private List<IParser> _knownParsers;
    
        public ParserFactory()
        {
            // you should be able to initialize this dynamically but that's off-topic here
            _knownParsers = new List<IParser> { new FcPortParser(), new FcipPortParser() };
        }
    
        public IParser GetFromString(string given)
        {
            // return the IParser with the longest prefix that given starts with
            // this will return null for a non-match
            return _knownParsers.Where(p => given.StartsWith(p.RequiredPrefix))
                                .OrderByDescending(p => p.RequiredPrefix.Length)
                                .FirstOrDefault();  
        }
    }
