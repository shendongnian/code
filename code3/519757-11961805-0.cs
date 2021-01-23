    public class MyContext : DbContext
    {
        public DbSet<Log> Logs { get; set; }
        public DbSet<LogEntry> LogEntries { get; set; }
    }
    var logEntry = context.LogEntries.SingleOrDefault(le => le.LogEntryId == someLogEntryId);
