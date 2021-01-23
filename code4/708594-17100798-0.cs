    var builder = new ConfigurationSourceBuilder();
    builder.ConfigureLogging()
                    .LogToCategoryNamed("General")
                    .WithOptions.SetAsDefaultCategory()
                    .SendTo.RollingFile("Rolling Flat File Trace Listener")
                    .CleanUpArchivedFilesWhenMoreThan(7)
                    .WhenRollFileExists(RollFileExistsBehavior.Increment)
                    .WithTraceOptions(TraceOptions.Timestamp)
                    .RollEvery(RollInterval.Day)
                    .UseTimeStampPattern("yyyy-MM-dd")
                    .ToFile(logPath)
                    .FormatWith(
                        new FormatterBuilder()
                            .TextFormatterNamed("Text Formatter")
                            .UsingTemplate("{timestamp}:{title}:{message}"))
                    .WithFooter("").WithHeader("")
                    .SpecialSources
                        .LoggingErrorsAndWarningsCategory
                        .SendTo.FlatFile("Flat File Trace Listener")
                        .ToFile("errors.log");
