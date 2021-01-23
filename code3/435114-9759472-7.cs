    using (var sw = new StreamWriter(@"C:\linksLog.txt", true)) {
        foreach (var link in linksList) {
            try {
                Process.Start(browserType, list);                        
            } catch (Exception) {}
            sw.WriteLine(link);
        
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
