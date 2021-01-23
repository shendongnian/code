    public void Clear()
    {
        if (this._size > 0)
        {
            Array.Clear(this._items, 0, this._size);
            this._size = 0;
        }
        List`1 list`1s = this;
        list`1s._version = list`1s._version + 1;
    }
