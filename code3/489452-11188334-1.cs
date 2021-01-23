    // C#
    public void ConnectToAccess()
    {
        System.Data.OleDb.OleDbConnection conn = new 
            System.Data.OleDb.OleDbConnection();
        // TODO: Modify the connection string and include any
        // additional required properties for your database.
        conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
            @"Data source= C:\Documents and Settings\username\" +
            @"My Documents\AccessFile.mdb";
        try
        {
            conn.Open();
            // Insert code to process data.
        }
            catch (Exception ex)
        {
            MessageBox.Show("Failed to connect to data source");
        }
        finally
        {
            conn.Close();
        }
    }
