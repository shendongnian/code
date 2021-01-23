    void pTask_Exited(object sender, EventArgs e)
    {
        Process p = (Process)sender;
        TimeSpan duration = p.ExitTime - p.StartTime;
        bool success = p.ExitCode == 0;
    }
