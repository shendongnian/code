    public static int GetTotalLogEntries(XmlReader reader)
    {
        var count = 0;
        while (reader.Read())
        {
            if (reader.IsStartElement("LogData"))
            {
                count++;
            }
        }
        return count;
    }
