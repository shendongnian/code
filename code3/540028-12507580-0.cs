	// System.Collections.Generic.List<T>
	/// <summary>Removes the element at the specified index of the <see cref="T:System.Collections.Generic.List`1" />.</summary>
	/// <param name="index">The zero-based index of the element to remove.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	///   <paramref name="index" /> is less than 0.-or-<paramref name="index" /> is equal to or greater than <see cref="P:System.Collections.Generic.List`1.Count" />.</exception>
	public void RemoveAt(int index)
	{
		if (index >= this._size)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException();
		}
		this._size--;
		if (index < this._size)
		{
			Array.Copy(this._items, index + 1, this._items, index, this._size - index);
		}
		this._items[this._size] = default(T);
		this._version++;
	}
