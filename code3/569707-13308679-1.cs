    protected void FilterGrid(object sender, EventArgs e)
    {
        TextBox txtFilter = (TextBox)sender;
        string[] parts = txtFilter.Text.Split();
        int row = int.Parse(parts[0]);
        int col = int.Parse(parts[1]);
        gridView1.DataSource = GetData(row, col);
        gridView1.DataBind();
    }
    // replace with your DAL, used a DataTable for testing
    private DataTable GetData(int rowIndex = -1, int colIndex = -1)
    {
        DataTable tblData = getDataSource(); 
        if (rowIndex > -1 && colIndex > -1)
        {
            var field = tblData.Columns[colIndex];
            var row = tblData.Rows[rowIndex];
            var value = row[field];
            // now use Linq-To-DataSet to filter the table, remember to add 'using System.Linq'
            tblData = tblData.AsEnumerable()
                .Where(r => !r.IsNull(field) && r[field].Equals(value))
                .CopyToDataTable();
        }
        return tblData;
    }
