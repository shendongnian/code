    ConcurrentDictionary<String, Nullable<int>> htTempVal = 
               new ConcurrentDictionary<String, Nullable<int>>();
    Parallel.ForEach (listx,
      x =>
      {
          String temp1 = x.sc;
          String temp2 = x.key.Trim();
          Nullable<int> temp3 = x.val;
    
          if ((null != temp2) && (string.Empty != temp2) && 
              (int.MinValue != temp3) && "Fetch" == temp1)
          {
              htTempVal.GetOrAdd(temp2, temp3);
          }
      });
