    var table = new DataTable();
    const string sql = "SELECT * FROM dbo.YourTable ORDER BY SomeColumn";
    using(var con = new SqlConnection(Properties.Settings.Default.ConnectionString))
    using(var da  = new SqlDataAdapter(sql, con))
    {
        da.Fill(table);
    }
