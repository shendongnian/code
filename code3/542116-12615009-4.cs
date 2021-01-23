	public class EventLogger
	{
		private const string logName = "Application";
		private static string appName = "";
		private static bool sourceExists = false;
		public static string AppName
		{
			get { return appName; }
			set { appName = value; }
		}
		public static void Init(string appName)
		{
			AppName = appName;
			sourceExists = EventLog.SourceExists(AppName);
			if (!sourceExists)
			{
				EventLog.CreateEventSource(AppName, logName);
				sourceExists = true;
			}
		}
		private static void Write(string entry, EventLogEntryType logType, int eventID)
		{
			if (sourceExists)
			{
				EventLog.WriteEntry(AppName, entry, logType, eventID);
			}
		}
		public static void Warning(string entry) { Write(entry, EventLogEntryType.Warning, 200); }
		public static void Warning(string entry, int eventID) { Write(entry, EventLogEntryType.Warning, eventID); }
		public static void Error(string entry) { Write(entry, EventLogEntryType.Error, 300); }
		public static void Error(string entry, int eventID) { Write(entry, EventLogEntryType.Error, eventID); }
		public static void Info(string entry) { Write(entry, EventLogEntryType.Information, 100); }
		public static void Info(string entry, int eventID) { Write(entry, EventLogEntryType.Information, eventID); }
	}
