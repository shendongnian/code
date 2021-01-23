    var linesToWrite = new list<string>();
    
    linesToWrite.Add(status);
    linesToWrite.Add(cycleCount.ToString());
    ...
    
    File.WriteAllLines("C://springTestBackupData.txt", linesToWrite);
