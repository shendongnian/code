    string connectionString = "server=(local)\SQLEXPRESS;database=YourDatabaseName;user id=database;pwd=testdatabase";
    string insertStmt = "INSERT INTO dbo.Laptops(Name, Model, ScreenSize) " + 
                        "VALUES(@Name, @Model, @Screensize)";
    using(SqlConnection conn = new SqlConnection(connectionString))
    using(SqlCommand cmd = new SqlCommand(insertStmt, conn))
    {
        // set up the command's parameters
        cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = "ASUS SX30";
        cmd.Parameters.Add("@Model", SqlDbType.VarChar, 50).Value = "Ultralight";
        cmd.Parameters.Add("@Screensize", SqlDbType.Int).Value = 15;
        // open connection, execute command, close connection
        conn.Open();
        int result = cmd.ExecuteNonQuery();
        conn.Close();
    }
