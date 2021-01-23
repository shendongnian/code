    DataTable table = new Datatable();
    using(var con = new SqlConnection(connectionString))
    using(var cmd = new SqlCommand("SELECT * FROM dbo.Table WHERE ACTIVATE = 1", con))
    using(var da = new SqlDataAdapter(cmd))
    {
        da.Fill( table );
    }
