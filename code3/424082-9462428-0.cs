     foreach (var item in PathList)
     {
        Tuple<int, int> temp = new Tuple<int, int>(item.Key, 0);
           //if (x.Equals(item.Key) && x[item.Key].Equals(0))
        if (x.Contains<Tuple<int, int>>(temp))
          {
             string path1 = Path.Combine(GetDirectory(item.Value), item.Value);
             File.Delete(path1);
           }
       }
