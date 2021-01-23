    public int GetMessageCount(string queuePath)
    {
        const string query = "select * from Win32_PerfRawData_MSMQ_MSMQQueue";
        var wqlQuery = new WqlObjectQuery(query);
        var searcher = new ManagementObjectSearcher(wqlQuery);
        var managementObjects1 = searcher.Get();
        var managementObjects = managementObjects1;
        foreach (ManagementObject queue in managementObjects)
        {
            var name = queue["Name"].ToString();
            if (AreTheSameQueue(queuePath, name))
            {
                // Depending on the machine (32/64-bit), this value is a different type.
                // Casting directly to UInt64 or UInt32 only works on the relative CPU architecture.
                // To work around this run-time unknown, convert to string and then parse to int.
                var countAsString = queue["MessagesInQueue"].ToString();
                var messageCount = int.Parse(countAsString);
                return messageCount;
            }
        }
        return 0;
    }
    private static bool AreTheSameQueue(string path1, string path2)
    {
        // Tests whether two queue paths are equivalent, accounting for differences
        // in case and length (if one path was truncated, for example by WMI).
        string sanitizedPath1 = Sanitize(path1);
        string sanitizedPath2 = Sanitize(path2);
        if (sanitizedPath1.Length > sanitizedPath2.Length)
        {
            return sanitizedPath1.StartsWith(sanitizedPath2);
        }
        if (sanitizedPath1.Length < sanitizedPath2.Length)
        {
            return sanitizedPath2.StartsWith(sanitizedPath1);
        }
        return sanitizedPath1 == sanitizedPath2;
    }
    private static string Sanitize(string queueName)
    {
        var machineName = Environment.MachineName.ToLowerInvariant();
        return queueName.ToLowerInvariant().Replace(machineName, ".");
    }
