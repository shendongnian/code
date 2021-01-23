    public static void Tick(object source, ElapsedEventArgs e)
    {
        // Prevent another Tick from happening if this takes longer than 10 minutes
        (source as Timer).Enabled = false;
 
        // It would be better practice to put this in a settings or config file
        // so you can change it without having to recompile your application
        string connString = "Server=localhost;Port=3306;Database=communications;Uid=root;password=pass;";
        // I won't change them here, but since these classes implement IDisposable,
        // you should be using a using statement around them:
        // using (var conn = new MySqlConnection(connString))
        // {
        //     // use conn
        // }
        MySqlConnection conn = new MySqlConnection(connString);
        MySqlCommand command = conn.CreateCommand();
        MySqlCommand updateCommand = conn.CreateCommand();
        command.CommandText = "SELECT * FROM outbox WHERE `faxstat` = 'Y' AND `fax` <> '' AND `faxpro` = 'PENDING'";
        try
        {
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    SendFax(reader["id"].ToString(), reader["filepath"].ToString(), @"C:\FAXDOC\" + reader["filepath"].ToString(), reader["account"].ToString(), reader["fax"].ToString(), reader["fax_orig"].ToString());
                    string id = reader["id"].ToString();
                    // I would use a prepared statement with either this query
                    // or a stored procedure with parameters instead of manually
                    // building this string (more good practice than worrying about
                    // SQL injection as it's an internal app
                    updateCommand.CommandText = "UPDATE outbox SET `faxpro` = 'DONE' WHERE `id` = '" + id + "'";
                    updateCommand.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            LogException(ex.ToString());
            throw;
        } 
        finally 
        {
            // If you're not going to use using-statements, you might want to explicitly
            // call dispose on your disposable objects:
            // command.Dispose();
            // updateCommand.Dispose();
            conn.Close();
            // conn.Dispose();
        }
        
        // Enable the timer again
        (source as Timer).Enabled = true;
    }
