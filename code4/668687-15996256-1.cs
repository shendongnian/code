    namespace ClassLibrary1
    {
    public static class GetConfiguration
    {
    public static string ComputerName
    {
        get
        {
            return System.Configuration.ConfigurationManager.AppSettings["ComputerName"];
        }
    }
    }
    }
