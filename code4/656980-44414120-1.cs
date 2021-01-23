    public static void logList_add(string str)
        {
            try
            {
                try
                {
                    //critical section
                    Monitor.Enter(Program.logList);
                    Program.logList.Add(str);
                }
                finally
                {
                    Monitor.Exit(Program.logList);
                    //end critical section
                }
                //set start
                Program.evtLogListFilled.Set();
            }
            catch{}
        }
