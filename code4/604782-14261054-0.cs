      ...
      ICollection<T> collection1 = collection as ICollection<T>;
      if (collection1 != null)
      {
         ...
      }
      else
      {
        foreach (T obj in collection)
          this.Insert(index++, obj);
      }
