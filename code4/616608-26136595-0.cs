    int RowsToAdd=3
    int rowCount = AlldaysList.Rows.Count;
    for (int i = 0; i < rowCount; i++)
    {
       for (int j = 0; j < RowsToAdd; j++)
       {
         DataRow dr = AlldaysList.NewRow();
         dr["scenarionid"] = DBNull.Value;
         dr["description"] = "";
         
         AlldaysList.Rows.Add(dr);
       }
    }
