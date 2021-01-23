    private void button1_Click(object sender, EventArgs e)
    {
        ProcessStartInfo pi = new ProcessStartInfo();
        pi.Verb = "runas";
        pi.WindowStyle = ProcessWindowStyle.Hidden;
        foreach(string s in myProcesses)
        {
             pi.FileName = s;
             Process.Start(pi);
             Thread.Sleep(10000);
        }
     }
