    protected void Page_Load(object sender, EventArgs e)
    {
        List<string> cols = GetColDefsFromBackend();
        List<List<string>> rows = GetDataFromBackend();
    
    
        GridView1.DataSource = CreateDataTable(cols, rows);
        GridView1.DataBind();
    }
    
    
    private System.Data.DataTable CreateDataTable(List<string> columnDefinitions, List<List<string>> rows)
    {
        DataTable table = new DataTable();
        foreach (string colDef in columnDefinitions)
        {
            DataColumn column;
            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = colDef;
            table.Columns.Add(column);
        }
    
    
        // Create DataRow and Add it to table
        foreach (List<string> rowData in rows)
        {
            DataRow row = table.NewRow();
            // rowData is in same order as columnDefinitions
            for (int i = 0; i < rowData.Count; i++)
            {
                row[i] = rowData[i];
            }
            table.Rows.Add(row);
        }
    
    
        return table;
    }
    
    
    /// <summary>
    /// Simulates a StoredProcedureCall which returns
    /// the data in a List with Lists of strings
    /// </summary>
    private List<List<string>> GetDataFromBackend()
    {
        List<List<string>> myData = new List<List<string>>();
        myData.Add(Row(1));
        myData.Add(Row(2));
        myData.Add(Row(3));
        return myData;
    }
    
    
    private List<string> Row(int p)
    {
        List<string> row = new List<string>();
        for (int i = 0; i < 4; i++)
        {
            row.Add(string.Format("Column {0}/{1}", p, i));
        }
        return row;
    }     
    
    private List<string> GetColDefsFromBackend()
    {
        List<string> cols = new List<string>();
        cols.Add("Col1");
        cols.Add("Col2");
        cols.Add("Col3");
        cols.Add("Col4");
        return cols;
    }
