    public void StartProcessAndWathTillTerminated(string tempFilePath)
    {
        // Show app selection dialog to user
        Process rundll32 = Process.Start("rundll32.exe", string.Format("shell32.dll,OpenAs_RunDLL {0}", tempFilePath));
        int rundll32id = rundll32.Id;
        // Wait till dialog is closed
        while (!rundll32.HasExited)
        {
            System.Threading.Thread.Sleep(50);
        }
        
        // Get all running processes with parent id
        Dictionary<int, int> allprocparents = GetAllProcessParentPids();
        
        int openedAppId = 0;
        // Loop throu all processes
        foreach (var allprocparent in allprocparents)
        {
            // Found child process, started by our rundll32.exe instance
            if (allprocparent.Value == rundll32id)
            {
                openedAppId = allprocparent.Key;
                break;
            }
        }
        // Check if we actually found any process. It can not be found in two situations:
        // 1) Process was closed too soon, while we was looking for it
        // 2) User clicked Cancel and no application was opened
        // Also it is possible that chesen application is already running. In this
        // case new instance will be opened by rundll32.exe for a very short period of 
        //time needed to pass file path to running instance. Anyway, this case falls into case 1).
        
       //If we ca not find process explicitly, we can try to find it by file lock, if one exists:
       //I'm using here a code snippet from https://stackoverflow.com/a/1263609/880156,
       //which assumes that there are possible more than one lock on this file. 
       //I just take first. 
       if (openedAppId==0)
        {
            Process handleExe = new Process();
            handleExe.StartInfo.FileName = "handle.exe";
            handleExe.StartInfo.Arguments = tempFilePath;
            handleExe.StartInfo.UseShellExecute = false;
            handleExe.StartInfo.RedirectStandardOutput = true;
            handleExe.Start();           
            handleExe.WaitForExit();
            string outputhandleExe = handleExe.StandardOutput.ReadToEnd();
            string matchPattern = @"(?<=\s+pid:\s+)\b(\d+)\b(?=\s+)";
            foreach(Match match in Regex.Matches(outputhandleExe, matchPattern))
            {
                openedAppId  = int.Parse(match.Value);
                break;
            }
        }
        if (openedAppId != 0)
        {
            Process openedApp = Process.GetProcessById(openedAppId);
            while (!openedApp.HasExited)
            {
                System.Threading.Thread.Sleep(50);
            }
        }
        // When we reach this position, App is already closed or was never started.
    }
    public static Dictionary<int, int> GetAllProcessParentPids()
    {
        var childPidToParentPid = new Dictionary<int, int>();
        var processCounters = new SortedDictionary<string, PerformanceCounter[]>();
        var category = new PerformanceCounterCategory("Process");
        // As the base system always has more than one process running, 
        // don't special case a single instance return.
        var instanceNames = category.GetInstanceNames();
        foreach(string t in instanceNames)
        {
            try
            {
                processCounters[t] = category.GetCounters(t);
            }
            catch (InvalidOperationException)
            {
                // Transient processes may no longer exist between 
                // GetInstanceNames and when the counters are queried.
            }
        }
        foreach (var kvp in processCounters)
        {
            int childPid = -1;
            int parentPid = -1;
            foreach (var counter in kvp.Value)
            {
                if ("ID Process".CompareTo(counter.CounterName) == 0)
                {
                    childPid = (int)(counter.NextValue());
                }
                else if ("Creating Process ID".CompareTo(counter.CounterName) == 0)
                {
                    parentPid = (int)(counter.NextValue());
                }
            }
            if (childPid != -1 && parentPid != -1)
            {
                childPidToParentPid[childPid] = parentPid;
            }
        }
        return childPidToParentPid;
    }
