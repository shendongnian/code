	string indexPageText = string.Empty;
	SqlConnection myConnection = new SqlConnection(Variables.connectionString());
	SqlCommand myCommand = new SqlCommand("IndexPagesGetByIndexPageID", myConnection);
	myCommand.CommandType = CommandType.StoredProcedure;
	SqlParameter parameterIndexPageID = new SqlParameter("@IndexPageID", SqlDbType.Int);
	parameterIndexPageID.Value = indexPageID;
	myCommand.Parameters.Add(parameterIndexPageID);
	myConnection.Open();
	SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
	while (result.Read())
	{
		indexPageText = (string)result["IndexPageText"];
		break;
	}
	result.Close();
	indexPageDetails.indexPageText = indexPageText;
