	// System.Collections.Generic.Stack<T>
	/// <summary>Removes and returns the object at the top of the <see cref="T:System.Collections.Generic.Stack`1" />.</summary>
	/// <returns>The object removed from the top of the <see cref="T:System.Collections.Generic.Stack`1" />.</returns>
	/// <exception cref="T:System.InvalidOperationException">The <see cref="T:System.Collections.Generic.Stack`1" /> is empty.</exception>
	public T Pop()
	{
		if (this._size == 0)
		{
			ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EmptyStack);
		}
		this._version++;
		T result = this._array[--this._size];
		this._array[this._size] = default(T);
		return result;
	}
