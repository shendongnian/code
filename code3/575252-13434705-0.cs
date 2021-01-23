    foreach (string s in System.Environment.GetCommandLineArgs())
            {
                if (s == "-h")
                {
                    hideToTray();
                }
            }
