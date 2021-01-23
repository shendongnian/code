    public static void InsertImage(Contributor contObj, string ImageName)
    {
        string sqlString = "INSERT INTO Images (UID, Name) " +
            "VALUES (@UID, @Name)";
        using (SqlCeConnection sqlConnection =
            new SqlCeConnection(WebConfigurationManager.ConnectionStrings["DefaultSQL"].ConnectionString))
        {
            SqlCeCommand sqlCommand = new SqlCeCommand(sqlString, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@UID", contObj.ID);
            sqlCommand.Parameters.AddWithValue("@Name", ImageName);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
