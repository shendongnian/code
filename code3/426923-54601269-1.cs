    private static void writeToDataTable(string ServerHostname, string RootDirectory, string RecordType, string Path, string PathDirectory, string PathFileName, string PathFileExtension, decimal SizeBytes, decimal SizeMB, DateTime DateCreated, DateTime DateModified, DateTime DateLastAccessed, string Owner, int PathLength, DateTime RecordWriteDateTime)
        {
            try
            {
                if (tableToggle)
                {
                    DataRow toInsert = results_1.NewRow();
                    toInsert[0] = ServerHostname;
                    toInsert[1] = RootDirectory;
                    toInsert[2] = RecordType;
                    toInsert[3] = Path;
                    toInsert[4] = PathDirectory;
                    toInsert[5] = PathFileName;
                    toInsert[6] = PathFileExtension;
                    toInsert[7] = SizeBytes;
                    toInsert[8] = SizeMB;
                    toInsert[9] = DateCreated;
                    toInsert[10] = DateModified;
                    toInsert[11] = DateLastAccessed;
                    toInsert[12] = Owner;
                    toInsert[13] = PathLength;
                    toInsert[14] = RecordWriteDateTime;
                    results_1.Rows.Add(toInsert);
                }
                else
                {
                    DataRow toInsert = results_2.NewRow();
                    toInsert[0] = ServerHostname;
                    toInsert[1] = RootDirectory;
                    toInsert[2] = RecordType;
                    toInsert[3] = Path;
                    toInsert[4] = PathDirectory;
                    toInsert[5] = PathFileName;
                    toInsert[6] = PathFileExtension;
                    toInsert[7] = SizeBytes;
                    toInsert[8] = SizeMB;
                    toInsert[9] = DateCreated;
                    toInsert[10] = DateModified;
                    toInsert[11] = DateLastAccessed;
                    toInsert[12] = Owner;
                    toInsert[13] = PathLength;
                    toInsert[14] = RecordWriteDateTime;
                    results_2.Rows.Add(toInsert);
                }
                
            }
            catch (Exception error)
            {
                errorLogging(error, getCurrentMethod(), logFile);
            }
        }
