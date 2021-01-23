     List<int> GetAllExcelProcessID()
        {
           List<int> ProcessID = new List<int>(); 
           if (currentExcelProcessID == -1)
            {
               List<System.Diagnostics.Process> currentExcelProcessList = System.Diagnostics.Process.GetProcessesByName("EXCEL").ToList();
               foreach(var item in currentExcelProcessList)
                {
                    ProcessID.Add(item.Id);
                }
            }
           return ProcessID;
        }
    int GetApplicationExcelProcessID(List<int> ProcessID1, List<int> ProcessID2)
        {
            foreach(var processid in ProcessID2)
            {
                if (!ProcessID1.Contains(processid)) { currentExcelProcessID = processid; }
            }
            return currentExcelProcessID;
        }
     void KillExcel()
        {
            System.Diagnostics.Process process = System.Diagnostics.Process.GetProcessById(currentExcelProcessID);
            process.Kill();
        }
     List<int> ProcessID1 = GetAllExcelProcessID();
                    excel = new Excel.Application();
                    List<int> ProcessID2 = GetAllExcelProcessID();
                    currentExcelProcessID = GetApplicationExcelProcessID(ProcessID1, ProcessID2);
