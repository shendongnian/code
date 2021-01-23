     public Configuration()
     {
        AutomaticMigrationsEnabled = false;
        SetSqlGenerator("System.Data.SQLite", new SQLiteMigrationSqlGenerator());
     }
