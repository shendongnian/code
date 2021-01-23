        public static async void  WriteTrace(TraceEventType eventType, string msg, [CallerMemberName] string methodName = "")
        {
             const string TEXT_FILE_NAME = "Trace.txt";
            string logMessage = eventType.ToString() + "\t" + methodName + "\t" + msg ;
            IEnumerable<string> lines = new List<string>() { logMessage }; 
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFolder tempFolder = ApplicationData.Current.TemporaryFolder;
            //if(localFolder.CreateFolderQuery(Windows.Storage.Search.CommonFolderQuery.)
            StorageFolder LogFolder = await localFolder.CreateFolderAsync("LogFiles", CreationCollisionOption.OpenIfExists);
            await LogFolder.CreateFileAsync(TEXT_FILE_NAME, CreationCollisionOption.OpenIfExists);
            StorageFile logFile = await LogFolder.GetFileAsync(TEXT_FILE_NAME);
            await FileIO.AppendLinesAsync(logFile, lines);
            
        }
