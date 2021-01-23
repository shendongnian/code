        public void GetProcessId()
        {
            var processList = System.Diagnostics.Process.GetProcessesByName("taskmgr");
               
            // note that you get a list, there may be multiple processes returned
            foreach (var process in processList)
            {
                // print out the process id
                System.Console.WriteLine("Process Id=" + process.Id);
            }
        }
