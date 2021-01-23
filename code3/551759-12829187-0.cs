    private DataTable GetSchemeForTable(string tableName)
    {
        DataTable ret = new DataTable();
    
        try
        {
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = string.Format("SELECT * FROM [{0}] WHERE 1 = 2;", tableName);
            using (IDataReader reader = command.ExecuteReader(CommandBehavior.SchemaOnly))
            {
                ret.Load(reader);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception in GetSchemeForTable: " + ex.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            connection.Dispose();
        }
    
        return ret;
    }
