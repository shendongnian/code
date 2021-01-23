    SQLiteConnectionStringBuilder conn_builder = new SQLiteConnectionStringBuilder 
    { 
       DateTimeFormat = SQLiteDateFormats.ISO8601,
       SyncMode = SynchronizationModes.Off,
       Version = 3,
       JournalMode = SQLiteJournalModeEnum.Truncate,
       DefaultIsolationLevel = System.Data.IsolationLevel.ReadCommitted,
       Pooling = true,
       Uri = new Uri(@"c:\tmp\db.sqlite").AbsoluteUri
     };
     string conn_str = conn_builder.ConnectionString;
