    foreach(type key in a.keys)
    {
      //a1 I think. adds a key not in b
      if(!b.ContainsKey(key))
      {
        b.Add(key, a[key]);
      }
      else
      {
        //a2 I think... I suppose that the value is a list of properties
        foreach(type prop in a[key])
        {
          if(!b[key].Contains(prop))
          {
            b[key].Add(prop);
          }
        }
      }
    }  
