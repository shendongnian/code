    object item = null;
    foreach (var a in items)
    {
      // if item is set then we can use it.
      if (item != null)
      {
          // not final item
          f(item);
      }
      item = a;
    }
    
    // final item.
    g(item);
