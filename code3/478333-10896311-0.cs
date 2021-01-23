    public static void DataTableToFile(string fileLoc, DataTable dt)
    {
        StringBuilder str = new StringBuilder();
            
        // get the column headers
        str += String.Join(",", dt.Columns.Cast<DataColumn>()
                                          .Select(col => col.ColumnName);
        str.AppendLine();
        // write the data here
        foreach (DataRow dr in dt.Rows)
        {
            str += string.Join(",", dr.ItemArray.Select(x => x.ToString());
            str.AppendLine();
        }
        try
        {
            Write(fileLoc, str.ToString());
        }
        catch (Exception ex)
        {
            //ToDO:Add error logging
        }
    }
