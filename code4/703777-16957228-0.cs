    foreach (DataColumn col in dt.Columns)
    {
      if(!col.ColumnName.ToLower().Equals("xyz"))
       {
         rowelement.Add(get(col.ColumnName,dr[col.ColumnName].ToString())); 
       }
    }
