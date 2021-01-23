    using System;
    using System.Configuration;
    class Program {
        static void Main(string[] args) {
            try {
                string str = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                Console.WriteLine(str);
            } catch (ConfigurationErrorsException exc) {
                Console.WriteLine(exc.Message);
                if (exc.InnerException != null) {
                    Console.WriteLine(exc.InnerException.Message);
                }
            }
        }
    }
