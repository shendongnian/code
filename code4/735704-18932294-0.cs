            FileSystemWatcher fswRunning = new FileSystemWatcher(Path.GetTempPath() + "AudioCuesheetEditor");
            fswRunning.Filter = "*.txt";
            fswRunning.Changed += delegate(object sender, FileSystemEventArgs e) {
                log.debug("FileSystemWatcher called Changed");
                if (pAudioCuesheetEditor != null)
                {
                    log.debug("pAudioCuesheetEditor != null");
                    pAudioCuesheetEditor.getObjMainWindow().Present();
                }
            };
            fswRunning.EnableRaisingEvents = true;
            Boolean bAlreadyRunning = false;
            Process[] arrPRunning = Process.GetProcesses();
            foreach (Process pRunning in arrPRunning)
            {
                Boolean bCheckProcessMatch = false;
                if (Environment.OSVersion.Platform == PlatformID.Unix)
                {
                    if (pRunning.HasExited == false)
                    {
                        log.debug("pRunning.ProcessName = " + pRunning.ProcessName + " pRunning.MainWindowTitle = " + pRunning.MainWindowTitle);
                        if (pRunning.ProcessName.ToLower().Contains("mono"))
                        {
                            for (int i = 0; i < pRunning.Modules.Count;i++)
                            {
                                if (pRunning.Modules[i].ModuleName.Contains("AudioCuesheetEditor"))
                                {
                                    bCheckProcessMatch = true;
                                    i = pRunning.Modules.Count;
                                }
                            }
                        }
                    }
                } 
                else
                {
                    log.debug("pRunning.ProcessName = " + pRunning.ProcessName);
                    if (pRunning.ProcessName == Process.GetCurrentProcess().ProcessName)
                    {
                        bCheckProcessMatch = true;
                    }
                }
                log.debug("bCheckProcessMatch == " + bCheckProcessMatch);
                if ((pRunning.Id != Process.GetCurrentProcess().Id) && (bCheckProcessMatch == true))
                {
                    log.info("Writing to file " + Path.GetTempPath() + "AudioCuesheetEditor" + Path.DirectorySeparatorChar + "message.txt");
                    File.WriteAllText(Path.GetTempPath() + "AudioCuesheetEditor" + Path.DirectorySeparatorChar + "message.txt","Present");
                    bAlreadyRunning = true;
                }
            }
            log.debug("bAlreadyRunning = " + bAlreadyRunning);
            if (bAlreadyRunning == false)
            {
                   //Start Application
            }
