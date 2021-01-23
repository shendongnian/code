    Process[] processes = Process.GetProcesses();
    foreach (Process pro in processes)
    {
        if (pro.MainWindowTitle != "")
        {
            listBox.Items.Add(pro.ProcessName + " - " + pro.MainWindowTitle);
        }
        else
        {
            listBox.Items.Add(pro.ProcessName);
        }
    }
