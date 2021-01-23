    class Program
    {
        static void Main(string[] args)
        {
            EventLog log = EventLog.GetEventLogs().First(o => o.Log == "Security");
            log.EnableRaisingEvents = true;
            log.EntryWritten += (s, e) => { Console.WriteLine(e.Entry.EntryType); };
            Console.WriteLine(log.LogDisplayName);
            Console.ReadKey();
        }
    }
