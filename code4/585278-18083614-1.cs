    class Program
        {
            static IEnumerable<EventLogRecord> LogRecordCollection(string filename, string xpathquery = "*")
            {
                var eventLogQuery = new EventLogQuery(filename, PathType.FilePath, xpathquery);
            using (var eventLogReader = new EventLogReader(eventLogQuery))
            {
                EventLogRecord eventLogRecord;
                while ((eventLogRecord = (EventLogRecord)eventLogReader.ReadEvent()) != null)
                    yield return eventLogRecord;
            }
        }
        static void Main(string[] args)
        {
            var path = "file.evtx";
            var start = new DateTime(2013, 06, 26, 0, 0, 0);
            var end = new DateTime(2013, 06, 27, 0, 0, 0);
            var t = from l in LogRecordCollection(path)
                   where l.TimeCreated > start
                   && l.TimeCreated < end
                   select l;
            foreach (var item in t)
            {
                var msg = item.Properties[0].Value.ToString();
                if (msg.Contains("[interesting key]"))
                {
                    Console.Write(item.TimeCreated);
                    Console.Write(";");
                    Console.Write(item.TaskDisplayName);
                    Console.Write(";");
                    Console.Write(item.ProviderName);
                    Console.Write(";");
                    Console.Write(msg);
                    Console.Write(";");
                    Console.WriteLine();
                }
            }
            Console.Read();
        }
    }
