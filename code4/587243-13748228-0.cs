        static void Main(string[] args)
        {
            List<string> drives = new List<string>();
            // Assuming you put the API calls in Class1
            foreach (var item in Class1.WNetResource())
            {
                // WNetResource returns the drive letters without a trailing slash
                drives.Add(String.Concat(item.Key, @"\"));
            }
            foreach (var item in Environment.GetLogicalDrives())
            {
                if (!drives.Contains(item))
                    drives.Add(item);
            }
            drives.Sort();
            foreach (var drive in drives)
            {
                Console.WriteLine(drive);
            }
        }
