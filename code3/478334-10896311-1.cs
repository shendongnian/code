    public static void DataTableToFile(string fileLoc, DataTable dt)
    {
        StringBuilder str = new StringBuilder();
            
        // get the column headers
        str.Append(String.Join(",", dt.Columns.Cast<DataColumn>()
                                          .Select(col => col.ColumnName));
        str.AppendLine();
        // write the data here
        foreach (DataRow dr in dt.Rows)
        {
            str.Append(string.Join(",", dr.ItemArray));
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
