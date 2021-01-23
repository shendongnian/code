    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace TestAsync.Services
    {
        public static class AppSettings
        {
            public static string SettingsFileLocation {get; set;}
    
            public static string Setting1 { get; set; }
            public static string Setting2 { get; set; }
            public static DateTime Setting3 { get; set; }
    
            static AppSettings()
            {           
                SettingsFileLocation = @"C:\Wherever\Whatever.config";
                LoadConfiguration();
            }
    
            public static void LoadConfiguration()
            {
               using(var fs = new StreamReader(File.OpenRead(SettingsFileLocation)))
               {
                   Setting1 = fs.ReadLine();
                   Setting2 = fs.ReadLine();
                   Setting3 = DateTime.Parse(fs.ReadLine());
                   fs.Close();
               }
              
            }
    
            public static void SaveConfiguration()
            {
                using (var fs = new StreamWriter(File.OpenWrite(SettingsFileLocation)))
                {
                    fs.WriteLine(Setting1);
                    fs.WriteLine(Setting2);
                    fs.WriteLine(Setting3.ToShortDateString());
                    fs.Flush();
                    fs.Close();
                }
            }
        }
    }
