    using System;
    using System.Collections.Generic;
    using System.Management;
    using System.Text;
    namespace GetWMI_Info
    {
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string ComputerName = "remote-machine";
                ManagementScope Scope;
                if (!ComputerName.Equals("localhost", StringComparison.OrdinalIgnoreCase))
                {
                    ConnectionOptions Conn = new ConnectionOptions();
                    Conn.Username = "username";
                    Conn.Password = "password";
                    Conn.Authority = "ntlmdomain:DOMAIN";
                    Scope = new ManagementScope(String.Format("\\\\{0}\\root\\CIMV2", ComputerName), Conn);
                }
                else
                    Scope = new ManagementScope(String.Format("\\\\{0}\\root\\CIMV2", ComputerName), null);
                Scope.Connect();
                ObjectQuery Query = new ObjectQuery("SELECT LogonId  FROM Win32_LogonSession Where LogonType=2");
                ManagementObjectSearcher Searcher = new ManagementObjectSearcher(Scope, Query);
                foreach (ManagementObject WmiObject in Searcher.Get())
                {
                    Console.WriteLine("{0,-35} {1,-40}", "LogonId", WmiObject["LogonId"]);// String
                    ObjectQuery LQuery = new ObjectQuery("Associators of {Win32_LogonSession.LogonId=" + WmiObject["LogonId"] + "} Where AssocClass=Win32_LoggedOnUser Role=Dependent");
                    ManagementObjectSearcher LSearcher = new ManagementObjectSearcher(Scope, LQuery);
                    foreach (ManagementObject LWmiObject in LSearcher.Get())
                    {
                        Console.WriteLine("{0,-35} {1,-40}", "Name", LWmiObject["Name"]);                    
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("Exception {0} Trace {1}", e.Message, e.StackTrace));
            }
            Console.WriteLine("Press Enter to exit");
            Console.Read();
        }
    }
    }
