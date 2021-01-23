    internal class Program
    {
        private static void Main(string[] args)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
            var mos = searcher.Get();
            foreach (ManagementObject mo in mos)
            {
                foreach (PropertyData property in mo.Properties)
                {
                    if (property.Name == "Description")
                    {
                        Console.WriteLine(property.Value);
                    }
                }
            }
            Console.ReadKey();
        }
    }
