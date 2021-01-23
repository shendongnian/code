    public class MyDbConfiguration : DbConfiguration
    {
        public MyDbConfiguration()
        {
            SetProviderServices(SqlCeProviderServices.ProviderInvariantName, SqlCeProviderServices.Instance);
            var directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			var path = Path.Combine(directory, @"ApplicationName\MyDatabase.sdf");			
            var connectionString = string.Format(@"Data Source={0}",path);
            SetDefaultConnectionFactory(new SqlCeConnectionFactory(SqlCeProviderServices.ProviderInvariantName, "", connectionString));
        }
    }  
