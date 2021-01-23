    public static EventRecord GetEventRecord(string eventFile, int eventID)
    {
      var xpathQuery = string.Format("*[System/EventID={0}]", eventID);
      var query = new EventLogQuery(eventFile, PathType.FilePath, xpathQuery);
      var reader = new EventLogReader(query);
      return reader.ReadEvent();
    }
