    internal static IEnumerable<TResult> ExecuteQueryNullSafe<TResult>(this System.Data.Linq.DataContext context, string command, params object[] parameters)
    {
      var list = new List<object>();
      var listVals = new List<bool>();
    
      for (int x = 0; x < parameters.Count(); x++)
      {
        if (parameters[x] == null || parameters[x] is System.DBNull)
        {
          command = command.Replace("{" + x + "}", "NULL");
          listVals.Add(false);
        }
        else
        {
          list.Add(parameters[x]);
          listVals.Add(true);
        }
      }
    
      int nextId = 0;
      for (int i = 0; i < listVals.Count; i++)
      {
        var isUsed = listVals[i];
        if (!isUsed)
          continue;
        if (nextId != i)
          command = command.Replace("{" + i.ToString() + "}", "{" + nextId.ToString() + "}");
        nextId++;
      }
    
      return context.ExecuteQuery<TResult>(command, list.ToArray());
    }
