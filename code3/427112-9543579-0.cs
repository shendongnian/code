    public static void UpdateRows(string table, string columnToGet,
                 string columnValueGet, string columnToSet, string columnValueToSet)
    {
        try
        {
            SqlConnection connection = new SqlConnection(Global.connectionString);
            string updateString =
                       "UPDATE " + table + " " +
                       "SET " + columnToSet   + "= @columnValueToSet " + 
                       "WHERE " + columnToGet + "= @columnValueGet;";
            Console.WriteLine(updateString);
            using (SqlCommand cmd = new SqlCommand(updateString, connection))
            {
                connection.Open();
                cmd.Parameters.AddWithValue("@columnValueToSet", columnValueToSet);
                cmd.Parameters.AddWithValue("@columnValueGet", columnValueGet);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            throw;
        }
     }
