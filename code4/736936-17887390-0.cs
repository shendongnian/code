    string[] result = new string[50];
    int count = 0;
    Process[] processes = Process.GetProcesses();
    foreach(var process in processes)
    {
        if (process.MainWindowTitle
                   .IndexOf("e", StringComparison.InvariantCulture) > -1)
        {
            result[count] = process.MainWindowTitle;
            count++;
        }
    }
