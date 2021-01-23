    string[] logFileList = Directory.GetFiles(Path.GetTempPath(), "add_all_*.log", SearchOption.TopDirectoryOnly);
    if (logFileList.Count() > 1)
    {
        Array.Sort(logFileList, 0, logFileList.Count());
    }
    
    if (logFileList.Any())
    {
        string currFilePath = logFileList.Last();
        string[] dotSplit = currFilePath.Split('.');
        string lastChars = dotSplit[0].Substring(dotSplit[0].Length - 3);
        ctr = Int32.Parse(lastChars);
        FileInfo f = new FileInfo(currFilePath);
    
        if (f.Length > MaxLogSize)
        {
            if (logFileList.Count() > MaxLogCount)
            {
                File.Delete(logFileList[0]);
                for (int i = 1; i < MaxLogCount + 1; i++)
                {
                    Debug.WriteLine(string.Format("moving: {0} {1}", logFileList[i], logFileList[i - 1]));
                    File.Move(logFileList[i], logFileList[i - 1]); // push older log files back, in order to pop new log on top
                }
            }
            else
            {
                ctr++;
            }
        }
    }
