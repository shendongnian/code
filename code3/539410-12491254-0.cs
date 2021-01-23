        private MyApplicationDataContext()
        { }
        public static MyApplicationDataContext CreateInstance()
        {
            var directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(directory, @"ApplicationName\MyDatabase.sdf");
            // Set connection string
            var connectionString = string.Format("Data Source={0}", path);
            Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0", "", connectionString);
            return new MyApplicationDataContext();
        }
