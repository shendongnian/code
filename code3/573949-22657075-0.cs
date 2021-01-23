    Parallel.ForEach(
                                        chunkFiles,
                                        new ParallelOptions { MaxDegreeOfParallelism = 2 },
                                        chunk =>
                                        {
                                            //create new paralel process - count limited to MaxDegreeOfParallelism
                                            Process p = ProcessManager.GenerateProcessInstance();
                                            p.StartInfo.Arguments = string.Format("{0} {1} {2} {3}", chunk, Id, logFileName, infoFileName);
                                            p.Start();
                                            p.WaitForExit();
                                            sentEmails += p.ExitCode;
                                        }
                                    );
