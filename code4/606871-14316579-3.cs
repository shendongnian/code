    private void DeleteRecord(string ID)
    {
        SqlConnection connection = new SqlConnection("YOUR CONNECTION STRING");
        string sqlStatement = "DELETE FROM Table1 WHERE Id = @Id";
    try
    {
        connection.Open();
        SqlCommand cmd = new SqlCommand(sqlStatement, connection);
        cmd.Parameters.AddWithValue("@Id", ID);
        cmd.CommandType = CommandType.Text;
        cmd.ExecuteNonQuery();
    }
    catch (System.Data.SqlClient.SqlException ex)
    {
        string msg = "Deletion Error:";
        msg += ex.Message;
        throw new Exception(msg);
    }
    finally
    {
        connection.Close();
    }
    }
