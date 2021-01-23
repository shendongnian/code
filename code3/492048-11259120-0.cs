    private List<string> _items;
    ...
    public List<string> Items
    {
        get
        {
            if (_items == null)
            {
                _items = new List<string>();
                // load items
            }
            return _items;
        }
    }
