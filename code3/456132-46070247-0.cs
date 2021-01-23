      public static output ExecuteBlockwithLogging<output, input, config>(ExeBlock<output, input, config> exeBlock, input InputForExeBlock, ILoggingBlock logger)
        {
            exeBlock.Execute(InputForExeBlock);
            if ((exeBlock.logEntries != null) && (exeBlock.logEntries.Length > 0))
            {
                logger.Execute(exeBlock.logEntries);
            }
            if ((exeBlock.exceptions != null) && (exeBlock.exceptions.Length > 0))
            {
                foreach (var e in exeBlock.exceptions)
                {
                    var dictionaryData = new Dictionary<string, string>();
                    if (e.Data.Count > 0)
                    {
                        foreach (DictionaryEntry d in e.Data)
                        {
                            dictionaryData.Add(d.Key.ToString(), d.Value.ToString());
                        }
                    }
                    var messages = e.FromHierarchy(ex => ex.InnerException).Select(ex => ex.Message);
                    LoggingEntry LE = new LoggingEntry
                    {
                        description = e.Message,
                        exceptionMessage = String.Join(Environment.NewLine, messages),
                        source = exeBlock.GetType().Name,
                        data = dictionaryData
                    };
                    logger.Execute(new LoggingEntry[] { LE });
                }
                return default(output);
            }
            return exeBlock.Result;
        }
