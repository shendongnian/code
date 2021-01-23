    // your connection string
    string connectionString = "Server=(local)\\netsdk;uid=sa;pwd=;database=master";
    // your query:
    var query = GetDbCreationQuery();
    var conn = new SqlConnection(connectionString);
    var command = new SqlCommand(query, conn);
    try
    {
        conn.Open();
        command.ExecuteNonQuery();
        MessageBox.Show("Database is created successfully", "MyProgram", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.ToString());
    }
    finally
    {
        if ((conn.State == ConnectionState.Open))
        {
            conn.Close();
        }
    }
