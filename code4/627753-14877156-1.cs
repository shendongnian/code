    foreach (var record in recordList)
    {  
        dbWatch.Restart();
        DbService.UpdateRecord(Id, ProcessDate, MessageID, task.Result.Email.TryTimes);
        dbWatch.Stop();
        LogMessage(string.Format("Single database row update took:{0}",dbWatch.Elapsed));
    }
