    private static void manageDataTables()
        {
            try
            {
                Console.WriteLine(@"[Checking datatable size] toggleValue: " + tableToggle + " | " + @"r1: " + results_1.Rows.Count + " - " + @"r2: " + results_2.Rows.Count);
                if (tableToggle)
                {
                    int rowCount = 0;
                    if (results_1.Rows.Count > datatableRecordCountThreshhold)
                    {
                        tableToggle ^= true;
                        writeToLog(@"results_1 row count > 100000 @ " + results_1.Rows.Count, logDatabaseFile, getLineNumber(), getCurrentMethod(), true);
                        rowCount = results_1.Rows.Count;
                        logResultsFile = "FileServerReport_Results_" + DateTime.Now.ToString("yyyyMMDD-HHmmss") + ".txt";
                        Thread.Sleep(30000);
                        writeToLog(@"results_1 row count stopped increasing, updating database...", logDatabaseFile, getLineNumber(), getCurrentMethod(), true);
                        updateDatabase(results_1);
                        results_1.Clear();
                        writeToLog(@"results_1 cleared, count: " + results_1.Rows.Count, logDatabaseFile, getLineNumber(), getCurrentMethod(), true);
                    }
                    
                }
                else
                {
                    int rowCount = 0;
                    if (results_2.Rows.Count > datatableRecordCountThreshhold)
                    {
                        tableToggle ^= true;
                        writeToLog(@"results_2 row count > 100000 @ " + results_2.Rows.Count, logDatabaseFile, getLineNumber(), getCurrentMethod(), true);
                        rowCount = results_2.Rows.Count;
                        logResultsFile = "FileServerReport_Results_" + DateTime.Now.ToString("HHmmss") + ".txt";
                        Thread.Sleep(5000);
                        if (results_2.Rows.Count != rowCount)
                        {
                            writeToLog(@"results_2 row count increased, @ " + results_2.Rows.Count, logDatabaseFile, getLineNumber(), getCurrentMethod(), true);
                            rowCount = results_2.Rows.Count;
                            Thread.Sleep(30000);
                        }
                        writeToLog(@"results_2 row count stopped increasing, updating database...", logDatabaseFile, getLineNumber(), getCurrentMethod(), true);
                        updateDatabase(results_2);
                        results_2.Clear();
                        writeToLog(@"results_2 cleared, count: " + results_2.Rows.Count, logDatabaseFile, getLineNumber(), getCurrentMethod(), true);
                    }
                }
            }
            catch (Exception error)
            {
                errorLogging(error, getCurrentMethod(), logDatabaseFile);
            }
        }
