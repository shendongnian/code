    public static void CreateSqlDatabase(string filename)
    {
        string databaseName = System.IO.Path.GetFileNameWithoutExtension(filename);
        using (var connection = new System.Data.SqlClient.SqlConnection(
            "Data Source=.\\sqlexpress;Initial Catalog=tempdb; Integrated Security=true;User Instance=True;"))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    String.Format("CREATE DATABASE {0} ON PRIMARY (NAME={0}, FILENAME='{1}')", databaseName, filename);
                command.ExecuteNonQuery();
    
                command.CommandText =
                    String.Format("EXEC sp_detach_db '{0}', 'true'", databaseName);
                command.ExecuteNonQuery();
            }
        }
    }
