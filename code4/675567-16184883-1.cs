    SqlConnection con = new SqlConnection(MyconnectionString);
    con.Open();
    string SQLQuery = "SELECT EmailID, ServerName, receiveDateTime, Type, status, received, processed"
                + "FROM EmailTable, EmailTypesTable, ServerTable, StatusTable"
                + "WHERE EmailTypesTable.emailTypeID = EmailTypesTable.EmailType "
                + "AND ServerTable.ServerID = EmailTable.serverID "
                + "AND StatusTable.statusID = EmailTable.statusID "
                + "AND EmailTable.receiveDateTime BETWEEN @dateFrom AND @dateTo";
    SqlCommand cmd = new SqlCommand(SQLQuery );
    cmd.Parameters.AddWithValue("@dateFrom", fromDateTime.Value.ToString("g"));
    cmd.Parameters.AddWithValue("@dateTo", toDateTime.Value.ToString("g"));
    SqlDataReader reader = cmd.ExecuteReader();
    //...
