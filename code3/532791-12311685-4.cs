    private void Backup()
    {
        string file = "C:\\backup.sql";
        string conn = "server=localhost;user=root;pwd=qwerty;database=test;";
        MySqlBackup mb = new MySqlBackup(conn);
        mb.ExportInfo.FileName = file;
        mb.Export();
    }
