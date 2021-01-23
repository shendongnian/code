        IConfigurationSource configSource = ConfigurationSourceFactory.Create();
		var logSettings = configSource.GetSection(LoggingSettings.SectionName) as LoggingSettings;
		var rollFileTraceListener = logSettings.TraceListeners
			.FirstOrDefault(t => t is RollingFlatFileTraceListenerData && t.Name == "RollingFlatFileTraceListener")
			as RollingFlatFileTraceListenerData;
		string fileName = rollFileTraceListener.FileName;
		rollFileTraceListener.FileName = fileName.Replace("aaa", "bbb");
		LogWriterFactory f = new LogWriterFactory(configSource);
		f.Create();
		Logger.Reset();
		LogEntry logEntry = new LogEntry();
		logEntry.Message = $"{DateTime.Now} Count:{333}";
		logEntry.Categories.Clear();
		logEntry.Categories.Add("General");
		Logger.Write(logEntry);
