	public override bool Equals(object obj)
	{
		var logEntry = obj as LogEntry;
		if (logEntry == null)
			return false;
		return LogEntryId.Equals(logEntry.LogEntryId);
	}
	public override int GetHashCode()
	{
		return LogEntryId.GetHashCode();
	}
