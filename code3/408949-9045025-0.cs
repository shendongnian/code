    while (true)
    {
        Process backup;
        ProcessStartInfo check;
        if (Process.GetProcessesByName(file).Length == 0)
        {
            check = new ProcessStartInfo(file);//moved init
            backup = new Process();//moved init
            if(File.Exists(file))
            {
                backup.StartInfo = check;
                backup.Start();
            }
            else if (!File.Exists(file))
            {
                File.Copy(backupFile, file);
                Thread.Sleep(250);
                backup.StartInfo = check;
                backup.Start();
            }
        }
        backup.Close();
        Thread.Sleep(2000);
    }
