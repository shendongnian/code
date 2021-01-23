    public class AssemblyConfiguration : MarshalByRefObject
    {
        public static string GetConnectionString(string name)
        {
            Assembly callingAssembly = Assembly.GetEntryAssembly();
            var conStringCollection = ConfigurationManager.OpenExeConfiguration(callingAssembly.Location).ConnectionStrings;
            return conStringCollection?.ConnectionStrings[name].ConnectionString;
        }
    }
