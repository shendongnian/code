    SqlConnectionStringBuilder builder =
                        new SqlConnectionStringBuilder(GetConnectionString());
        
        builder.ConnectionString = "Server=DLS-534\\SQL_2008_R2_DEV;user id=sa;password=Mypassword;initial catalog=master";
        
    connString = builder;
                    using (var connection = new SqlConnection(connString))
                    {
                        try
                        {
                            connection.Open();
                            return true;
                        }
                        catch (SqlException)
                        {
                            return false;
                        }
                    }
