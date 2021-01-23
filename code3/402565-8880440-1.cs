    // Declared outside the method.
    private const string InsertSql = 
        "insert into PROJECT_SHIP (CR_Number, Ship_Id) " +
        "VALUES (@CR_Number, @CCF_Number)";
    ...
    string[] shipIds = ShipsInScope.Split('|');
    foreach (string shipId in shipIds)
    {
        using (SqlCommand command = new SqlCommand(InsertSql, connection))
        {
            command.Parameters.Add("@CR_Number", SqlDbType.NVarChar, 10)
                              .Value = crNumber; // Unclear what this means
            command.Parameters.Add("@Ship_Id", SqlDbType.NVarChar, 10)
                              .Value = shipId;
            command.ExecuteNonQuery();
        }
    }
