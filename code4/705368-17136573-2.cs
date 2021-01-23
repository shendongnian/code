    private void btn_AddToQueue_Click(object sender, RoutedEventArgs e)
    {
        BackupTask bt = new BackupTask();
        bt.MachineName = //load these
        bt.Username = // from your 
        bt.Password = //textboxes
        bt.CurrentFile = "";
        bt.OverallProgress = 0;
        AddOrModifyTask(bt);    
        listView1.ItemsSource = tasks;
    }
    private void btn_StartBackup_Click(object sender, RoutedEventArgs e)
    {
        if (!bw.IsBusy)
            bw.RunWorkerAsync();
    }
