    public static void DataTableToFile(string fileLoc, DataTable dt)
    {
        StringBuilder str = new StringBuilder();
            
        // get the column headers
        str.Append(String.Join(",", dt.Columns.Cast<DataColumn>()
                                          .Select(col => col.ColumnName)) + "\r\n");
        // write the data here
        dt.Rows.Cast<DataRow>().ToList()
               .ForEach(row => str.Append(string.Join(",", row.ItemArray) + "\r\n"));
        try
        {
            Write(fileLoc, str.ToString());
        }
        catch (Exception ex)
        {
            //ToDO:Add error logging
        }
    }
