    query = "SELECT DateString FROM table WHERE DateArrivage = 'DefaultValue' ";
    using (OdbcDataReader reader = ObAccess.SQLSELECT(query))
    {
        if (reader.Read())
        {
            DateWithoutDate = reader.GetString(0);
        }
        else
        {
            // Whatever you want to do if there are no rows
        }
    }
