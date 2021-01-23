    public static List<T> TableToList<T>(DataTable table)
    {
      List<T> rez = new List<T>();
      foreach (DataRow rw in table.Rows)
      {
        T item = Activator.CreateInstance<T>();
        foreach (DataColumn cl in table.Columns)
        {
          PropertyInfo pi = typeof(T).GetProperty(cl.ColumnName);
          if (pi != null && rw[cl] != DBNull.Value)
            pi.SetValue(item, Convert.ChangeType(rw[cl], pi.PropertyType), new object[0]);
  
        }
        rez.Add(item);
      }
      return rez;
    }
