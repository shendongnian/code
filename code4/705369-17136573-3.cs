    void AddOrModifyTask(BackupTask t)
    {
        bool found = false;
        foreach (BackupTask bt in tasks)
        {
            if (bt.MachineName == t.MachineName)
            {
                found = true;
                bt.CurrentFile = t.CurrentFile;
                bt.OverallProgress = t.OverallProgress;
            }
        }
        if (!found)
            tasks.Add(t);
    }
