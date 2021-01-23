        bool processFound = false;
        foreach (Process proc in procs)
        {
            if (proc.ProcessName.Contains("chrome"))
            {
                processFound = true;
            }
        }
        if (processFound)
        {
            EnableComposition(false);
        }
        else
        {
            EnableComposition(true);
        }
