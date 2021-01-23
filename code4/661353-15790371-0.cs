    public static int GetLastInsertedID(DbConnection connection)
    {
        try
        {
            string query = "SELECT CONVERT(int, SCOPE_IDENTITY())";
            using (SqlCeCommand cmd = new SqlCeCommand(query, conn)) {
                return (int)cmd.ExecuteScalar();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Could not get last inserted ID. " + ex.Message);
            return 0;
        }
    }
