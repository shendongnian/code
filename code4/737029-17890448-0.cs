    Dictionary<string, Dictionary<string,IEnumerable<AGString>>> Data = new Dictionary<string, Dictionary<string,IEnumerable<AGString>>>();
    foreach(String k1 in data.keys)
    {
       foreach(String k2 in data[k1].keys)
       {
          foreach(AGString ag in data[k1][k2])
          {
             // do something with k1, k2 and ag
          }
       }
    } 
