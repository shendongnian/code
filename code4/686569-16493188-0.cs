    class HeaderItem
    {
        private string[] _headers = new string[6];
        private List<HeaderItem> _items;
        public string this[int index]
        {
            get
            {
                return _headers[index];
            }
            set
            {
                _headers[index] = value;
            }
        }
        public List<HeaderItem> Items
        {
            get
            {
                if (_items == null)
                    _items = new List<HeaderItem>();
                return _items;
            }            
        }
    }
