    string condition = "Vendor LIKE 'Microsoft%' AND Name = 'Exchange'";
    string[] selectedProperties = new string[] { "Version" };
    SelectQuery query = new SelectQuery("Win32_Product", condition, selectedProperties);
    
    using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
    using (ManagementObjectCollection products = searcher.Get())
        foreach (ManagementObject product in products)
        {
            string version = (string) product["Version"];
            
            // Do something with version...
        }
