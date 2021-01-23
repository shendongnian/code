            ...
            create new application pool
            ...
            sman.CommitChanges();
            int i = 0;
            const int max = 10;
            do
            {
                i++;
                try
                {
                    if (ObjectState.Stopped == pool.State)
                    {
                        write_log("Pool was stopped, starting: " + pool.Name);
                        pool.Start();
                    }
                    sman.CommitChanges();
                    break;
                }
                catch (System.Runtime.InteropServices.COMException e)
                {
                    if (i < max)
                    {
                        write_log("Waiting for IIS to activate new config...");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        throw new Exception(
                            "CommitChanges timed out efter " + max + " attempts.",
                            e);
                    }
                }
            } while (true);
            ...
