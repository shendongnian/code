    private bool IsSingleInstance()
        {
            string szCurrentProcessName = this.ProductName;
            Process[] processlist = Process.GetProcesses();
            foreach(Process theprocess in processlist)
            {
                string szProcessName = theprocess.MainModule.ModuleName.ToString();
                if (szProcessName.Contains(szCurrentProcessName))
                    return false;
            }
            return true;
        }
