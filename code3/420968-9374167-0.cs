    int i = 0;
    foreach (Process p in Process.GetProcesses("."))
    {
        if (p.MainWindowTitle.Length > 0)
        {
            if (p.MainWindowTitle.Substring(0, 31) == "NotepadName.txt")
            {
                i++;
                if(i == 2){
                    p.Kill();
                    break;
                }
            }
        }
    }
