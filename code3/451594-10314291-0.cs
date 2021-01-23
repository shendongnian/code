    string sArgs = "a all.zip a.txt b.txt c.txt";
    ProcessStartInfo psi = new ProcessStartInfo("7z.exe", sArgs);
    psi.UseShellExecute = false;
    psi.CreateNoWindow = false;
    psi.LoadUserProfile = false;
    Process proc = new Process();
    Task t1 = new Task(() =>
        {
            proc = Process.Start(psi);
            proc.WaitForExit();
        }
    );
    button13.Enabled = false;
    Task t2 = t1.ContinueWith((antecedent) =>
        {
            button13.Enabled = true;
        }, TaskScheduler.FromCurrentSynchronizationContext()
    );
    t1.Start();
