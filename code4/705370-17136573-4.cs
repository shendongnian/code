    void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        lock (tasks)
        {
            AddOrModifyTask((BackupTask)e.UserState);
        }
        listView1.ItemsSource = tasks;
        listView1.Items.Refresh();
    }
    void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        task_definitions = tasks;
        Parallel.ForEach(task_definitions, task =>
            {
                string computer = task.MachineName;
                string user = task.Username;
                string pass = task.Password;
                //your old Do_Work code
            });
    }
