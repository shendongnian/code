    namespace ConsoleApplication1
    {
        using System;
        using System.Management;
    
        class Program
        {
            static void Main(string[] args)
            {
                ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
                disk.Get();
                Console.WriteLine(disk["VolumeName"]);
                Console.ReadLine();
            }
        }
    }
