    using (var fs = new StreamWriter(@"C:\linksLog.txt", true)) {
        foreach (var link in linksList) {
            try {
                Process.Start(browserType, list);                        
            } catch (Exception) {}
        
            Thread.Sleep((int)delayTime);
        
            if (!cbNewtab.Checked) {
                var processes = Process.GetProcessesByName(getProcesses);
                foreach (var process in processes) {
                    try {
                        process.Kill();
                    } catch (Exception) {}
                }
            }
        }
    }
