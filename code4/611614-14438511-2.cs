    class LogEntry
    {
        public DateTime Timestamp { get; set; }
        public int HeartRate { get; set; }
    }
    
    var logEntries = new List<LogEntry>();
    
    for(int i = 0; i < data.Length; i+= 7)
    {
        if(data[i] == 0x0a && data[i + 1] == 0x0d)
            break;
        if(data[i] != 0x1e)
            throw new InvalidDataException();
    
        var logEntry = new LogEntry();
        var year = BcdToDecimal(data[i + 3]) + 2000;
        var month = BcdToDecimal(data[i + 2]);
        var day = BcdToDecimal(data[i + 1]);
        var hour = BcdToDecimal(data[i + 4]);
        var minute = BcdToDecimal(data[i + 5]);
        var heartRate = data[i + 6];
        logEntry.Timestamp = new DateTime(year, month, day, hour, minute, 0);
        logEntry.HeartRate = heartRate;
        logEntries.Add(logEntry);
    }
    byte BcdToDecimal(byte bcdValue)
    {
        return (byte)((bcdValue / 16 * 10) + (bcdValue % 16));
    }
