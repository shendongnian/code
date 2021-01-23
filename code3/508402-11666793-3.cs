    public foo GetCustomerDataByIds(IEnumerable<int> ids)
    {
        using (var command = new SqlCommand())
        using (var adatper = new SqlAdapter())
        using (var dataSet = new DataSet())
        {
            command.Text = "spGetCustomerByIds";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDS", GetDataTableOfIds(ids));
            // execute and return the stuff you're after
        }
    }
    private DataTable GetDataTableOfIds(IEnumerable<int> ids)
    {
        var table = new DataTable();
        table.Columns.Add(new DataColumns("ID", typeof(int));
        foreach (var id in ids)
        {
            table.Rows.Add(id);
        }
        return table;
    }
