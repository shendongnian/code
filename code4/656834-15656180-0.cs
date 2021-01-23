       DataTable TempData = new DataTable();
        TempData.Columns.Add("Quantity", typeof(string));
        TempData.Columns.Add("UnitPrice", typeof(string));
        for (Int32 i = 0; i < 5; i++)
        {
            DataRow row = TempData.NewRow();
            row[0] = CreateRow(DataFromDataBase, i, "Quantity");
            row[1] = CreateRow(DataFromDataBase, i, "UnitPrice");
            TempData.Rows.Add(row);
            
        }
    private string CreateRow(DataTable data, Int32 index, String ColumnName)
    {
       String[] quan =   data.Rows[0][ColumnName].ToString().Split(',');
       if (quan.Length >= index)
           return quan[index].ToString();
       else
           return "";
    }
