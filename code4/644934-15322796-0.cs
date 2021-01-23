    try
    {
        using(var con = new OleDbConnection(connectionString))
        using(var da = new OleDbDataAdapter("elect * from tbl_admin", con))
        {
            var table = new DataTable();
            da.Fill(table); // note that you don't need to open the connection with DataAdapter.Fill
            if (table.Rows.Count > 0)
            {
                // ...
            }
        }
    }
    catch (Exception e1)
    {
        // don't catch an exception if you don't handle it in a useful way(at least loggging)
        throw;
    }
