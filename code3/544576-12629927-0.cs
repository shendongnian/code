    public class Blah
    {
        private IList<string> _strings;
    
        public int Count
        {
            get { return this._strings.Count; }
        }
    
        public Blah(IList<string> strings)
        {
            _strings = strings;
        }
    }
