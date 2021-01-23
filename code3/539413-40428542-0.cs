    public class MyDbConfiguration : DbConfiguration
    {
        public MyDbConfiguration()
        {
            SetProviderServices(SqlCeProviderServices.ProviderInvariantName, SqlCeProviderServices.Instance);
            //var directory Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var directory = @"C:\Users\Evan\Desktop\TestFolder"; // Directory may or may not already exist
            Directory.CreateDirectory(directory);   // create directory if not exists         
            var path = Path.Combine(directory, @"ApplicationName\MyDatabase.sdf");          
            var connectionString = string.Format(@"Data Source={0}",path);
            SetDefaultConnectionFactory(new SqlCeConnectionFactory(SqlCeProviderServices.ProviderInvariantName, "", connectionString));
        }
    } 
