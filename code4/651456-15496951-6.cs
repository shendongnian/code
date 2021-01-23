    using(SqlConnection cn = dbconnection())
    {
        string sqlText = "SELECT * FROM Customers ORDER BY CustomerName";
        SqlCommand cmd = new SqlCommand(sqlText, con);
        DataTable dtCustomers = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dtCustomers);
        // Do what you want with the datatable (bind to a grid, return to do more processing...
    }
