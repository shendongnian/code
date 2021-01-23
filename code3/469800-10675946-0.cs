            var scope = new ManagementScope();
            scope.Connect();
            var query = new ObjectQuery("SELECT * FROM Win32_VideoController");
            using (var searcher = new ManagementObjectSearcher(scope, query))
            {
                var results = searcher.Get();
                foreach (var result in results)
                {
                    Console.WriteLine("Horizontal resolution: " + result.GetPropertyValue("CurrentHorizontalResolution"));
                    Console.WriteLine("Vertical resolution: " + result.GetPropertyValue("CurrentVerticalResolution"));
                }               
            }
