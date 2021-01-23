    public virtual IList Retrieve(Type type)
    {
      // ...
      listType = typeof(List<>).MakeGenericType(new Type[] { type });
      IList list = (IList)Activator.CreateInstance(listType);
      // ...
      return list
    }
