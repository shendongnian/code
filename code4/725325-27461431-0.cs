        internal void CreateDbBackup()  
    {  
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConStr"].ConnectionString))  
             {  
                SqlCommand cmd = con.CreateCommand();  
                cmd.CommandText = string.Format(@"BACKUP DATABASE [MyDatabase] TO  DISK = N'{0}' WITH  INIT ,  NOUNLOAD ,  NOSKIP ,  STATS = 10,  NOFORMAT", UtilityClassGeneral.DbBackupPath);  
                con.Open();  
                cmd.ExecuteNonQuery(); 
            }  
        }  
    
        internal void RestoreDbFromBackup()  
        {  
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConStr"].ConnectionString))  
            {  
                SqlCommand cmd = con.CreateCommand();  
    
                con.Open();  
    
                // Make sure to get exclusive access to DB to avoid any errors  
                cmd.CommandText = "USE MASTER ALTER DATABASE [MyDatabase] SET SINGLE_USER With ROLLBACK IMMEDIATE";  
                cmd.ExecuteNonQuery();  
    
                cmd.CommandText = string.Format(@"RESTORE DATABASE [MyDatabase] FROM  DISK = N'{0}' WITH  FILE = 1,  NOUNLOAD ,  STATS = 10,  RECOVERY ,  REPLACE", UtilityClassGeneral.DbBackupPath);  
                cmd.ExecuteNonQuery();  
            }  
    }
