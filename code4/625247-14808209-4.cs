    public static IEnumerable<LogData> GetLogData(XmlReader reader)
    {
        LogData logData = null;
        while (reader.Read())
        {
            if (reader.IsStartElement("LogData"))
            {
                logData = new LogData();
            }
            if (reader.Name == "LogData" && reader.NodeType == XmlNodeType.EndElement)
            {
                yield return logData;
            }
            if (reader.Name == "LogID")
            {
                logData.LogID = reader.ReadElementContentAsString();
            }
            else if (reader.Name == "LogDateTime")
            {
                logData.LogDateTime = reader.ReadElementContentAsString();
            }
            else if (reader.Name == "LogType")
            {
                logData.LogType = reader.ReadElementContentAsString();
            }
            ...
        }
    }
