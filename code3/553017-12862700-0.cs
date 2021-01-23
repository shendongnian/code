    using(var con = new SqlConnection("Data Source=Yourserver; Integrated Security=True;"))
    {
        con.Open();
        var databases = con.GetSchema("Databases");
        foreach (DataRow database in databases.Rows)
        {
            String dbName = database.Field<String>("database_name");
            short db_id = database.Field<short>("dbid");
            DateTime create_date = database.Field<DateTime>("create_date");
        }
    } 
