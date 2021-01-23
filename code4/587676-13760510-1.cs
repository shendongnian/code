    DataTable GetData() {
        
        SqlConnection connection=new SqlConnection();
        connection.ConnectionString="Put your connection string";
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "Your Sql Query Geos here";
        DataTable dt = new DataTable();
        try
        {
            command.Connection.Open();
            dt.Load(command.ExecuteReader());
        }
        catch (Exception ex)
        {
            // Log ur error;
        }
        finally {
            connection.Close();
        }
        return dt;
        }
