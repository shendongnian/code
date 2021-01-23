    TValue value;
    do
    {
      if (!TryGetValue(...))
      {
        value = AddValueFactoryDelegate(key);
        if (!TryAddInternal(...))
        {
          continue;
        }
        return value;
      }
      value = UpdateValueFactoryDelegate(key);
    } 
    while (!TryUpdate(...))
    return value;
