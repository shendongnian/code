    private void CreateDatabase()
        {
            string connection = "Data Source=localhost;Initial Catalog=master;User ID=sa;Password=abcd1234";
            FileInfo file = new FileInfo(Path.GetDirectoryName(Application.ExecutablePath) + "\\DBName.sql");
            string script = file.OpenText().ReadToEnd();
            script = script.Replace("DB_NAME_MDF", appPathDB).Replace("DB_NAME_LDF", appPathLog);
            ExecSql(script, connection, "DBName");
            file.OpenText().Close();
        }
