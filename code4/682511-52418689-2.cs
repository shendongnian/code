        public static List<Dictionary<string, string>> SelectStringsFromWMI(SelectQuery select, ManagementScope wmiScope)
        {
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmiScope, select))
            {
                using (ManagementObjectCollection objectCollection = searcher.Get())
                {
                    foreach (ManagementObject managementObject in objectCollection)
                    {
                        //With all new object we add new Dictionary
                        result.Add(new Dictionary<string, string>());
                        foreach (PropertyData property in managementObject.Properties)
                        {
                            //Always add data to newest Dictionary
                            result.Last().Add(property.Name, property.Value?.ToString());
                        }
                    }
                    return result;
                }
            }
        }
