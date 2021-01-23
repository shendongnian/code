    ICollection<T> is2 = collection as ICollection<T>;
    if (is2 != null)
    {
        int count = is2.Count;
        if (count > 0)
        {
            this.EnsureCapacity(this._size + count);
            if (index < this._size)
            {
                Array.Copy(this._items, index, this._items, index + count, this._size - index);
            }
            if (this == is2)
            {
                Array.Copy(this._items, 0, this._items, index, index);
                Array.Copy(this._items, (int) (index + count), this._items, (int) (index * 2), (int) (this._size - index));
            }
            else
            {
                T[] array = new T[count];
                is2.CopyTo(array, 0);
                array.CopyTo(this._items, index);
            }
            this._size += count;
        }
    }
