    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace _16852548
    {
        class Program
        {
            static void Main(string[] args)
            {
                NameValueCollection appSettings = ConfigurationManager.AppSettings;
    
                string field1Value = "Filename";
                string field2Value = ".";
                string field3Value = "txt";
    
                string fileFormat = appSettings["FileNameFormat"];
    
                Console.WriteLine(string.Format(fileFormat, field1Value, field2Value, field3Value));
            }
        }
    }
