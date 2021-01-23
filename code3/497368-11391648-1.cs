    public string this[int index]
    {
        get { return _items[index - _lowerBound]; }
        set { _items[index - _lowerBound] = value; }
    }
    public string this[int word, int position]
    {
        get { return _items[word - _lowerBound].Substring(position, 1); }
    }
