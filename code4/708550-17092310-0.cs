    using (SqlConnection defaultSqlConnection = new SqlConnection("Insert Connection String Here"))
    {
            string backupDb = "BACKUP DATABASE [DatabaseName] TO DISK = 'C:\\Users\\Account\\Desktop\\Database Name.bak'";
    
         using (SqlCommand backupCommand = new SqlCommand(backupDb, defaultSqlConnection))
         {
              defaultSqlConnection.Open();
              backupCommand.ExecuteNonQuery();
         }
    }
