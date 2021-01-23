                   var dte = GetDTE();
                    var debugger = dte.Debugger;
                    var processes = debugger.LocalProcesses;
                    int processIdToAttach; //your process id of second visual studio
                    foreach (var p in processes)
                    {
                        EnvDTE90.Process3 process3 = (EnvDTE90.Process3)p;
                        if (process3.ProcessID == processIdToAttach)
                        {
                            if (!process3.IsBeingDebugged)
                            {
                                if (doMixedModeDebugging)
                                {
                                    string[] arr = new string[] { "Managed", "Native" };
                                    process3.Attach2(arr);
                                }
                                else
                                {
                                    process3.Attach();
                                }
                            }
                            break;
                        }
                    }
