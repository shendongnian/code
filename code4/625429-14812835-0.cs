    using System.Collections.Specialized;
    using System.Configuration;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                NameValueCollection test = (NameValueCollection)ConfigurationManager.GetSection("genericAppSettings");
    
                string a = test["another"];
            }
        }
    }
