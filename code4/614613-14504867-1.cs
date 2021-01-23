    var conString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}"
                                 , Path.Combine(dir, "nik.mdb"));
    var conBuilder = new OleDbConnectionStringBuilder(conString);
    using (var con = new OleDbConnection(conBuilder.ConnectionString))
    {
        // ...
    }
