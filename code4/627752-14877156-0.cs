    dbWatch.Start();
    foreach (var record in recordList)
    {  
        DbService.UpdateRecord(Id, ProcessDate, MessageID, task.Result.Email.TryTimes);
    }
    dbWatch.Stop();
    LogMessage(string.Format("All updates took:{0}",dbWatch.Elapsed));
