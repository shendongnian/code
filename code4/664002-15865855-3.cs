    private int[] _items = new int[8];
    private int _count;
    public void Add(int x)
    {
       if (_count == _items.Lengh) {
           Array.Resize(ref _items, 2 * _items.Length);
       }
        _items[_count++] = x;
    }
