    public void RetrieveExcelFromDatabase(int ID, string excelFileName)
    {
        byte[] excelContents;
        string selectStmt = "SELECT BinaryContent FROM dbo.YourTableHere WHERE ID = @ID";
        using (SqlConnection connection = new SqlConnection("your-connection-string-here"))
        using (SqlCommand cmdSelect = new SqlCommand(selectStmt, connection))
        {
            cmdSelect.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            connection.Open();
            excelContents = (byte[])cmdSelect.ExecuteScalar();
            connection.Close();
        }
        File.WriteAllBytes(excelFileName, excelContents);
     }
