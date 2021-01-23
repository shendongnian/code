    private void button1_Click(object sender, EventArgs e)
    {
        Excel.Range[] rows = RandomRows(10, @"C:\test\whatever.xlsx");
    
        DataTable dt = new DataTable();
    
        bool ColumnsCreated = false;
    
        foreach(Excel.Range row in rows)
        {
            object[,] values = row.Value;
    
            int columnCount = values.Length;
    
            if(!ColumnsCreated)
            {
                for(int i = 0; i < columnCount; i++)
                {
                    DataColumn dc = new DataColumn(String.Format("Column {0}", i));
                    dt.Columns.Add(dc);
                    ColumnsCreated = true;
                }
            }
    
            DataRow dr = dt.NewRow();
    
            for (int i = 0; i < columnCount; i++)
            {
                dr[String.Format("Column {0}", i)] = values[1,i+1];
            }
    
            dt.Rows.Add(dr);
        }
    
        RandomExcelRows.DataSource = dt;
    }
