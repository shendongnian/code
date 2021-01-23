        public static void CreateEmployeeTable(string name)
        {
            const string createTableFormat = @"CREATE TABLE [{0}] ( 
                               Id INT IDENTITY NOT NULL PRIMARY KEY,
                               Job NVARCHAR(100) NULL, 
                               Pay NVARCHAR(100) NULL, 
                               TotalJobs NVARCHAR(100) NULL, 
                               TotalPay NVARCHAR(100) NULL)";
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }
          
            // Just replace with your connection string.
            using (SqlCeConnection cn = new SqlCeConnection(Settings.Default.LocalDbConnectionString))                       
            using (SqlCeCommand cmd = cn.CreateCommand())
            {                    
                cmd.CommandText = string.Format(createTableFormat, name);
                cn.Open();         
                cmd.ExecuteNonQuery()
            }            
        } 
