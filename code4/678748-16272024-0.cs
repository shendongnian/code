    namespace InspectionServices.Services
    {
        public class ConfigManager
        {
            public static string GetConnectionString()
            {
                return ConfigurationManager.ConnectionStrings["Inspection"].ConnectionString;
            }
        }
    }
