    var wmiQuery = new SelectQuery("SELECT * FROM Win32_NetworkAdapter " +
                                       "WHERE NetConnectionId != null " +
                                       "AND Manufacturer != 'Microsoft' ");
        using (var searcher = new ManagementObjectSearcher(wmiQuery))
        {
            foreach (ManagementObject item in searcher.Get())
            {
                if (((String)item["NetConnectionId"]) == "Local Area Connection")
                {
                    using (item)
                    {
                        item.InvokeMethod("Disable", null);
                    }
                }
            }
        }
