    class LogEntry
    {
        public DateTime Timestamp { get; set; }
        public int HeartRate { get; set; }
    }
    
    var logEntries = new List<LogEntry>();
    
    for(int i = 0; i < data.Length; i+= 7)
    {
        if(data[i] != 0x1e)
            throw InvalidDataException();
    
        var logEntry = new LogEntry();
        var year = data[i + 1];
        var month = data[i + 2];
        var day = data[i + 3];
        var hour = data[i + 4];
        var minute = data[i + 5];
        var second = data[i + 6];
        var heartRate = data[i + 7];
        logEntry.Timestamp = new DateTime(year, month, day, hour, minute, second);
        logEntry.HeartRate = heartRate;
        logEntries.Add(logEntry);
    }
