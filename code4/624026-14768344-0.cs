    private void CheckAllPorts()
    {
        while (true)
        {
            MultipleClock = false;
            OneClock = false;
            NoClock = false;
            portCount = 0;
            //clear the string list.
            MultiplePortNames.Clear();
            //create an object searcher and fill it with the path and the query provided above.
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
            try
            {
                var results = searcher.Get().Where(queryObj=>
                        queryObj["InstanceName"].ToString().Contains("USB") || 
                        queryObj["InstanceName"].ToString().Contains("FTDIBUS"));
                if (portCount != results.Count())
                {
                    portCount = results.Count();
                        
                    if (portCount > 1)
                    {
                        MultipleClock = true;
                    }
                    else if (portCount == 1)
                    {
                        OneClock = true;
                    }
                    else if (portCount == 0)
                    {
                        NoClock = true;
                    }
                    foreach (ManagementObject queryObj in results)
                    {
                            MultiplePortNames.Add(queryObj["PortName"].ToString());
                    }
                    form1.UpdateListBox(MultiplePortNames);
                }
            }
            catch
            {
                NoClock = true;
                form1.UpdateListBox(MultiplePortNames);
            }
            Debug.WriteLine("NoClock = " + NoClock);
            Debug.WriteLine("OneClock = " + OneClock);
            Debug.WriteLine("MultipleClock = " + MultipleClock);
            Thread.Sleep(500);
        }
    }
