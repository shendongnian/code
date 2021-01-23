    OnBackupStarts();
    //.. do stuff
    
     new TaskFactory().StartNew(() =>
                    {
                        OnBackupStarts()
                        //.. do stuff
                        OnBackupEnds();
                    });
    void OnBackupEnds()
        {
            if (BackupChanged != null)
            {
                BackupChanged(this, new BackupChangedEventArgs(BackupState.Done));
            }
        }
