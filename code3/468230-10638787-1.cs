    using System;
    using System.Configuration;
    using System.ServiceModel.Configuration;
    
    namespace ConsoleApplication49
    {
        class Program
        {
            static void Main(string[] args)
            {
                var config          = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var bingingsSection = BindingsSection.GetSection(config);
    
                string netTcpSource    = bingingsSection.NetTcpBinding.ElementInformation.Source;
                string basicHttpSource = bingingsSection.BasicHttpBinding.ElementInformation.Source;
    
                Console.WriteLine("Net TCP Binding came from \"{0}\"", netTcpSource);
                Console.WriteLine("Basic HTTP Binding came from \"{0}\"", basicHttpSource);
            }
        }
    }
