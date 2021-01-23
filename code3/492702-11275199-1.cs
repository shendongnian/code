    public virtual void set_Capacity(int value)
    {
        if (value < this._size)
        {
            throw new ArgumentOutOfRangeException("value", Environment.GetResourceString("ArgumentOutOfRange_SmallCapacity"));
        }
        if (value != this._items.Length)
        {
            if (value <= 0)
            {
                this._items = new object[4];
                goto IL_65;
            }
            object[] array = new object[value];
            if (this._size > 0)
            {
                Array.Copy(this._items, 0, array, 0, this._size);
            }
            this._items = array;
            return;
        }
        IL_65:
    }
