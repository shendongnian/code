    public int UpdateTable(string updateString, string MySqlConnectionString)
    {
        int returnValue = 0;
        MySqlConnection connection = new MySqlConnection(MySqlConnectionString);
        MySqlCommand command = new MySqlCommand(updateString, connection);
        try
        {
            connection.Open();
            command.ExecuteNonQuery();
        }
        catch (Exception err)
        {
            WriteErrorLog("Unable to update table: " + err.ToString() +
                " - Using SQL string: " + updateString + ".");
            //MessageBox.Show("An error has occured while updating the database.\n" +
            //"It has been written to the file: " + errorFile + ".", "Database Error");
            returnValue = -1;
        }
        finally
        {
            connection.Close();
        }
        return (returnValue);
    }
