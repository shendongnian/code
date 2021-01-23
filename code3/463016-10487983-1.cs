    TValue value;
    do
    {
      if (!TryGetValue(...))
      {
        value = addValueFactory(key);
        if (!TryAddInternal(...))
        {
          continue;
        }
        return value;
      }
      value = updateValueFactory(key);
    } 
    while (!TryUpdate(...))
    return value;
