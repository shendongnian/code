    public void RestoreDatabase(string restoreFile)
    {
        string dbFileName = "dbCPS.accdb";
        string extractedFile = Path.GetTempFileName();
        string CurrentDatabasePath = Path.Combine(Environment.CurrentDirectory, dbFileName);
        using (ZipFile zip = ZipFile.Read(restoreFile))
        {
            // Extract to a temporary name built by the Framework for you....
            zip.ExtractAll(extractedFile);
        }
        // Now, before copying over the accdb file, you need to be sure that there is no
        // open OleDbConnection to this file, otherwise the IOException occurs because you
        // cannot change that file while it is actively used by a OleDbConnection
        
        // something like global_conn.Close(); global_conn.Dispose();
        File.Copy(extractedFile, CurrentDatabasePath, true);
        MessageBox.Show("Restore successful! "); 
        // and then reopen the connection
    }
