    Dictionary<string, Dictionary<string,IEnumerable<AGString>>> Data = new Dictionary<string, Dictionary<string,IEnumerable<AGString>>>();
    foreach(string k1 in Data.Keys)
    {
       foreach(string k2 in Data[k1].Keys)
       {
          foreach(AGString ag in Data[k1][k2])
          {
             // do something with k1, k2 and ag
          }
       }
    } 
