     public class MyIdentifiers : IEnumerable<MyProviderInfo>
     {
        public int Count
        {
            get { return _myProviderInfos.Count; }
        }
    
        public IEnumerator<MyProviderInfo> GetEnumerator()
        {
            return ((IEnumerable<MyProviderInfo>)_myProviderInfos ).GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    
        private static readonly IList<MyProviderInfo> _myProviderInfos = new[]
        {
            new MyProviderInfo
                {
                    MyProvider = MyProvider.FirstProvider,
                    Url = "https://www.google.com",                       
                }
        };
     }
