    // FindAppInPathDirectories("ruby.exe");
    public string FindAppInPathDirectories(string app)
    {
        string enviromentPath = System.Environment.GetEnvironmentVariable("PATH");
        string[] paths = enviromentPath.Split(';');
        foreach (string thisPath in paths)
        {
            string thisFile = System.IO.Path.Combine(thisPath, app);
            string[] executableExtensions = new string[] { ".exe", ".com", ".bat", ".sh", ".vbs", ".vbscript", ".vbe", ".js", ".rb", ".cmd", ".cpl", ".ws", ".wsf", ".msc", ".gadget" };
            foreach (string extension in executableExtensions)
            {
                string fullFile = thisFile + extension;
                try
                {
                    if (System.IO.File.Exists(fullFile))
                        return fullFile;
                }
                catch (System.Exception ex)
                {
                    Log("{0}:\r\n{1}",
                         System.DateTime.Now.ToString(m_Configuration.DateTimeFormat, System.Globalization.CultureInfo.InvariantCulture)
                        , "Error trying to check existence of file \"" + fullFile + "\""
                    );
                    Log("Exception details:");
                    Log(" - Exception type: {0}", ex.GetType().FullName);
                    Log(" - Exception Message:");
                    Log(ex.Message);
                    Log(" - Exception Stacktrace:");
                    Log(ex.StackTrace);
                } // End Catch 
            } // Next extension 
        } // Next thisPath 
        foreach (string thisPath in paths)
        {
            string thisFile = System.IO.Path.Combine(thisPath, app);
            try
            {
                if (System.IO.File.Exists(thisFile))
                    return thisFile;
            }
            catch (System.Exception ex)
            {
                Log("{0}:\r\n{1}",
                     System.DateTime.Now.ToString(m_Configuration.DateTimeFormat, System.Globalization.CultureInfo.InvariantCulture)
                    , "Error trying to check existence of file \"" + thisFile + "\""
                );
                Log("Exception details:");
                Log(" - Exception type: {0}", ex.GetType().FullName);
                Log(" - Exception Message:");
                Log(ex.Message);
                Log(" - Exception Stacktrace:");
                Log(ex.StackTrace);
            } // End Catch 
            
        } // Next thisPath 
        return app;
    } // End Function FindAppInPathDirectories 
