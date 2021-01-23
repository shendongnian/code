    using System;
    using System.IO;
    using System.Text;
    class Test
    {
        public static void Main()
        {
            string path = @"/proc/acpi/thermal_zone/THRM/temperature";
            if (!File.Exists(path))
            {
                Console.WriteLine("Could not find "+path);
                return;
            }
      
            string readText = File.ReadAllText(path);
            Console.WriteLine(readText);
        }
    }
