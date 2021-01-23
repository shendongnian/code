    private void LoadProcesses()
    {
        comboBox1.Items.Clear();
        Process[] MyProcess = Process.GetProcesses();
        for (int i = 0; i < MyProcess.Length; i++)
            comboBox1.Items.Add(string.Format("{0} - {1}", MyProcess[i].ProcessName, MyProcess[i].Id));
    
    }
