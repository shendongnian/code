        private IList<ItemType> _list;
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
