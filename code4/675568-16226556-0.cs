    SqlConnection con = new SqlConnection(MyconnectionString);
    con.Open();
    string SQLQuery = "SELECT EmailID, receiveDateTime " 
                    + "WHERE EmailTable.receiveDateTime " 
                    + "BETWEEN @dateFrom AND @dateTo";
    SqlCommand cmd = new SqlCommand(SQLQuery );
    cmd.Parameters.AddWithValue("@dateFrom", fromDateTime.Value.ToOADate());
    cmd.Parameters.AddWithValue("@dateTo", toDateTime.Value.ToOADate());
