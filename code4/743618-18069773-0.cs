    <TextBlock Name="txtBukva" Text="{Binding Index}"/>
    class X
    {
        public string Index { get; set; }
        public string Odgovor { get; set; }
    }
    class MyViewModel
    {
        private List<X> _items;
        public List<X> Items
        {
            get
            {
                return _items;
            }
            set
            {
                Debug.Assert(_items.Count <= 26);
                _items = value;
                for(int i = 0; i < _items.Count; i++)
                {
                    _items[i].Index = ('A' + i) + "";
                }
            }
        }
    }
