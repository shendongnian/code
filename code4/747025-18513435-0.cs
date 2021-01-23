    PsqlCommand cm = new PsqlCommand();
    cm.CommandText = "psp_tables";
    cm.CommandType = CommandType.StoredProcedure;
    cm.Connection = new PsqlConnection();
    cm.Connection.ConnectionString = <your connection string>;
    cm.Parameters.Add(":database_qualifier", DBNull.Value);
    cm.Parameters.Add(":table_name", DBNull.Value);
    cm.Parameters.Add(":table_type", "User table");
