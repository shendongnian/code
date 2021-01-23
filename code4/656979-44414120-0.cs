    private void bw_DoWorkLog(object sender, DoWorkEventArgs e)
        {
            StringBuilder toFile = new StringBuilder();
            while (true)
            {
                try
                {
                    {
                        //waiting form a signal
                        Program.evtLogListFilled.WaitOne();
                        try
                        {
                            //critical section
                            Monitor.Enter(Program.logList);
                            int max = Program.logList.Count;
                            for (int i = 0; i < max; i++)
                            {
                                SetText(Program.logList[0]);
                                toFile.Append(Program.logList[0]);
                                toFile.Append("\r\n");
                                Program.logList.RemoveAt(0);
                            }
                        }
                        finally
                        {
                            Monitor.Exit(Program.logList);
                            // end critical section
                        }
                        
                        try
                        {
                            if (toFile.Length > 0)
                            {
                                Logger.Log(toFile.ToString().Substring(0, toFile.Length - 2));
                                toFile.Clear();
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Log(System.Reflection.MethodBase.GetCurrentMethod(), ex);
                }
                Thread.Sleep(100);
            }
        }
