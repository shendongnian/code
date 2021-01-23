                    if (!Logger.Writer.IsLoggingEnabled()) return;
                var logEntry = new LogEntry { Severity = GetTraceEventTypeFromPriority(severity) };
                logEntry.Categories.Add(GetLogCategory(app_name, severity)); // CHANGED TO NONE BECAUSE SITECORE SUCKS
                logEntry.Priority = (int)severity;
                if (!Logger.ShouldLog(logEntry)) return;
                logEntry.Message = message;
                logEntry.Title = GetLogTitle(RequestDataManager.RequestData.blah, message, severity);
                
                lock (_locker)
                {
                    Logger.Write(logEntry);
                }
