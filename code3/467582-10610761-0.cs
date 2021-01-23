    public static void RemoveExtraColumns(DataTable dt)
    {
      // get original column count from extended property
      while(dt.Columns.Count > originalColumnCount)
        dt.Columns.RemoveAt(dt.Columns.Count -1);
    }
  
