    private void Restore()
    {
        string file = "C:\\backup.sql";
        string conn = "server=localhost;user=root;pwd=qwerty;database=test;";
        MySqlBackup mb = new MySqlBackup(conn);
        mb.ProgressCompleted += new MySqlBackup.progressComplete(mb_ProgressCompleted);
        mb.Import(file);
    }
    
    void mb_ProgressCompleted(object sender, MySqlBackupCompleteArg e)
    {
        string msg = e.ProcessType + " " + e.CompletedType;
        MessageBox.Show(msg);
    }
