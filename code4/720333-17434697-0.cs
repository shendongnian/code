    public class Features: IEnumerable<string>
    {
        private readonly Dictionary<string,string> _internalCollection;
        
        public Features()
        {
            _internalCollection = new Dictionary<string,string>();
        }
        
        private string GetByKey(string id)
        {
            if(!_internalCollection.ContainsKey(id))
                return null;
            return _internalCollection[id];
        }
        private void SetByKey(string id, string value) 
        {
            _internalCollection[id]=value;
        }
        const string _favoriteId = "favorite";
        public string Favorite
        {
             get { return GetByKey(_favoriteId); }
             set { return SetByKey(_favoriteId,value);}
        }
        
        const string _niceId = "nice";
        public string Nice
        {
             get { return GetByKey(_niceId);}
             set { return SetByKey(_niceId, value);} 
        }
        public string this[string index]
        {
                get { return GetByKey(index.ToLower()); }
                set { return SetByKey(index.ToLower(), value);}  
        }
        
        public IEnumerator<string> GetEnumerator()
        {
            foreach(var key in _internalCollection.Keys)
                yield return _internalCollection[key];
            yield break;
        }
    }
