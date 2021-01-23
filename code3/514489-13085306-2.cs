    //Kill the all EXCEL obj from the Task Manager(Process)
    System.Diagnostics.Process[] objProcess = System.Diagnostics.Process.GetProcessesByName("EXCEL");
    
    if (objProcess.Length > 0)
    {
        System.Collections.Hashtable objHashtable = new System.Collections.Hashtable();
        
        // check to kill the right process
        foreach (System.Diagnostics.Process processInExcel in objProcess)
        {
            if (objHashtable.ContainsKey(processInExcel.Id) == false)
            {
                 processInExcel.Kill();
            }
        }
        objProcess = null;
    }
    
    //In case of you want to quit what you have created the Excel object from your application //just use below condition in above,
    
        if(processInExcel.MainWindowTitle.ToString()== "")
