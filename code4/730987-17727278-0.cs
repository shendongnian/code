     public List(IEnumerable<T> collection)
        {
          if (collection == null)
            ThrowHelper.ThrowArgumentNullException(ExceptionArgument.collection);
          ICollection<T> collection1 = collection as ICollection<T>;
          if (collection1 != null)
          {
            int count = collection1.Count;
            if (count == 0)
            {
              this._items = List<T>._emptyArray;
            }
            else
            {
              this._items = new T[count];
              collection1.CopyTo(this._items, 0);
              this._size = count;
            }
          }
          else
          {
            this._size = 0;
            this._items = List<T>._emptyArray;
            foreach (T obj in collection)
              this.Add(obj);
          }
        }
