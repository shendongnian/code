    public static void DeleteLine(string kv)
    {
        OleDbConnection myConnection = GetConnection();
        string myQuery = "DELETE FROM Cloth WHERE [ClothName] = '" + kv + "'";
        OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);
 
        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception in DBHandler", ex);
        }
        finally
        {
            myConnection.Close();
        }
    }
