    IConfigurationSource configSource = ConfigurationSourceFactory.Create();
    var logSettings = configSource.GetSection(LoggingSettings.SectionName) as LoggingSettings;
    var flatFileTraceListener = logSettings.TraceListeners
        .FirstOrDefault(t => t is FlatFileTraceListenerData && t.Name == "Flat File Trace Listener")
        as FlatFileTraceListenerData;
    string fileName = flatFileTraceListener.FileName;
