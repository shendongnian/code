    string sqlCommandString = "SELECT StatementDate AS StateDate FROM dbTable " + 
        "WHERE AccountID = @AccountID ORDER BY StatementDate DESC";
    
    string ConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
    
    using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandString, sqlConnection))
    {
        sqlConnection.Open();
        sqlCommand.Parameters.AddWithValue("@AccountID", AccountID);
        DropDownList_StatementDate.DataSource = sqlCommand.ExecuteReader();
        DropDownList_StatementDate.DataBind();
    }
