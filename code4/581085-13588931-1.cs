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
          {
            var propType = Nullable.GetUnderlyingType(pi.PropertyType) ?? pi.PropertyType;
            pi.SetValue(item, Convert.ChangeType(rw[cl], propType), new object[0]);
  
        }
        rez.Add(item);
      }
      return rez;
    }
