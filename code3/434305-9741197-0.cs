    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management;
    using System.Text;
    
    namespace ConsoleFoo
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    ManagementObjectSearcher mgtObj = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_ComputerSystem");
                    foreach (ManagementObject item in mgtObj.Get())
                    {
                        Console.WriteLine("Number Of Processors  {0}", item["NumberOfProcessors"]);
                    }
                }
                catch (ManagementException e)
                {
                    Console.WriteLine("Exception {0} ", e.Message);
                }
                Console.ReadKey();
            }
        }
    }
