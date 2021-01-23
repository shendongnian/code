    internal static IEnumerable<string> GetConnectedCardNames()
    {
    string query = String.Format(@"SELECT * FROM Win32_NetworkAdapter");
    var searcher = new ManagementObjectSearcher
    {
        Query = new ObjectQuery(query)
    };
    try
    {
        log.Debug("Trying to select network adapters");
        var adapterObjects = searcher.Get();
        var names = (from ManagementObject o in adapterObjects
                        select o["Name"])
                            .Cast<string>();
        return names;
    }
    catch (Exception ex)
    {
        log.Debug("Failed to get needed names, see Exception log for details");
        log.Fatal(ex);
        throw;
    }
    }
