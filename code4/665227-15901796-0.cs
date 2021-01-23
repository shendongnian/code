    private static string GetBatteryLevel()
    {
        ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_Battery");
        using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
        {
            using (ManagementObjectCollection results = searcher.Get())
            {
                using (var enumerator = results.GetEnumerator())
                {
                    if (!enumerator.MoveNext())
                        return string.Empty;
    
                    return string.Format("{1} {0}%", enumerator.Current["EstimatedChargeRemaining"],
                                         enumerator.Current["BatteryStatus"].ToString() == "1"
                                             ? string.Empty
                                             : "Charging:");
                }
            }
        }
    }
