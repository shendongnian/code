    private static void processTargetDirectory(DirectoryInfo rootDirectory, string targetPathRoot)
        {
            DateTime StartTime = DateTime.Now;
            int directoryCount = 0;
            int fileCount = 0;
            try
            {                
                manageDataTables();
                Console.WriteLine(rootDirectory.FullName);
                writeToLog(@"Working in Directory: " + rootDirectory.FullName, logFile, getLineNumber(), getCurrentMethod(), true);
                applicationsDirectoryCount++;
                // REPORT DIRECTORY INFO //
                string directoryOwner = "";
                try
                {
                    directoryOwner = File.GetAccessControl(rootDirectory.FullName).GetOwner(typeof(System.Security.Principal.NTAccount)).ToString();
                }
                catch (Exception error)
                {
                    //writeToLog("\t" + rootDirectory.FullName, logExceptionsFile, getLineNumber(), getCurrentMethod(), true);
                    writeToLog("[" + error.Message + "] - " + rootDirectory.FullName, logExceptionsFile, getLineNumber(), getCurrentMethod(), true);
                    errorLogging(error, getCurrentMethod(), logFile);
                    directoryOwner = "SeparatedUser";
                }
                writeToRawLog(serverHostname + "," + targetPathRoot + "," + "Directory" + "," + rootDirectory.Name + "," + rootDirectory.Extension + "," + 0 + "," + 0 + "," + rootDirectory.CreationTime + "," + rootDirectory.LastWriteTime + "," + rootDirectory.LastAccessTime + "," + directoryOwner + "," + rootDirectory.FullName.Length + "," + DateTime.Now + "," + rootDirectory.FullName + "," + "", logResultsFile, true, logFile);
                //writeToDBLog(serverHostname, targetPathRoot, "Directory", rootDirectory.FullName, "", rootDirectory.Name, rootDirectory.Extension, 0, 0, rootDirectory.CreationTime, rootDirectory.LastWriteTime, rootDirectory.LastAccessTime, directoryOwner, rootDirectory.FullName.Length, DateTime.Now);
                writeToDataTable(serverHostname, targetPathRoot, "Directory", rootDirectory.FullName, "", rootDirectory.Name, rootDirectory.Extension, 0, 0, rootDirectory.CreationTime, rootDirectory.LastWriteTime, rootDirectory.LastAccessTime, directoryOwner, rootDirectory.FullName.Length, DateTime.Now);
                if (rootDirectory.GetDirectories().Length > 0)
                {
                    Parallel.ForEach(rootDirectory.GetDirectories(), new ParallelOptions { MaxDegreeOfParallelism = directoryDegreeOfParallelism }, dir =>
                    {
                        directoryCount++;
                        Interlocked.Increment(ref threadCount);
                        processTargetDirectory(dir, targetPathRoot);
                    });
                }
                // REPORT FILE INFO //
                Parallel.ForEach(rootDirectory.GetFiles(), new ParallelOptions { MaxDegreeOfParallelism = fileDegreeOfParallelism }, file =>
                {
                    applicationsFileCount++;
                    fileCount++;
                    Interlocked.Increment(ref threadCount);
                    processTargetFile(file, targetPathRoot);
                });
            }
            catch (Exception error)
            {
                writeToLog(error.Message, logExceptionsFile, getLineNumber(), getCurrentMethod(), true);
                errorLogging(error, getCurrentMethod(), logFile);
            }
            finally
            {
                Interlocked.Decrement(ref threadCount);
            }
            DateTime EndTime = DateTime.Now;
            writeToLog(@"Run time for " + rootDirectory.FullName + @" is: " + (EndTime - StartTime).ToString() + @" | File Count: " + fileCount + @", Directory Count: " + directoryCount, logTimingFile, getLineNumber(), getCurrentMethod(), true);
        }
