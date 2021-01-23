    using(var con = new SqlConnection("Data Source=Yourserver; Integrated Security=True;"))
    {
        con.Open();
        DataTable databases = con.GetSchema("Databases");
        foreach (DataRow database in databases.Rows)
        {
            String databaseName = database.Field<String>("database_name");
            short dbID = database.Field<short>("dbid");
            DateTime creationDate = database.Field<DateTime>("create_date");
        }
    } 
