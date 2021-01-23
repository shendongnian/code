    foreach (object item in row.ItemArray)
    {
         DateTime parsed;
         if (DateTime.TryParse(item.ToString(), out parsed))
         {
              writer.Write(String.Format("{0,-10}", parsed.ToString("MM-dd-yy") + ""));
         }
         else 
         {
              writer.Write(String.Format("{0,-10}", item.ToString() + ""));
         }
    }
    foreach (DataColumn col in jackTDataSet.Tables[0].Columns)
    {
         if (col.ColumnName == "Name of date Field ")
         {
             writer.Write(String.Format("{0,-10}", ((DateTime)row[col.ColumnName]).ToString("MM-dd-yy") + ""));
         }
         else 
         {
             writer.Write(String.Format("{0,-10}", row[col.ColumnName].ToString() + ""));
         }
    }
