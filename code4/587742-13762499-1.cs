        private IList<ItemType> _list = new List<ItemType>();
        public ItemType this[int i]
        {
            get
            {
                return _list[i];
            }
            set
            {
                _list[i] = value;
            }
        }
