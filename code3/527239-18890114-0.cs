            ThreadPool.QueueUserWorkItem((_) =>
                {
                    using (var query = new ManagementObjectSearcher("SELECT IDProcess, PercentProcessorTime, WorkingSet FROM Win32_PerfFormattedData_PerfProc_Process"))
                    {
                        try
                        {
                            query.Options.Timeout = new TimeSpan(0, 0, 10);
                            query.Options.ReturnImmediately = false;
                            Log.Info("Query built");
                            foreach (ManagementObject obj in query.Get())
                            {
                                using (obj)
                                {
                                    var key = (uint)obj.GetPropertyValue("IDProcess");
                                    Log.Info(key);
                                    processStats[key] = new ulong[] { (ulong)obj.GetPropertyValue("PercentProcessorTime"), (ulong)obj.GetPropertyValue("WorkingSet") };
                                }
                            }
                        }
                        catch (SystemException)
                        {
                        }
                    }
                });
