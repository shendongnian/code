    Microsoft.Office.Interop.Excel.Application excel = ...;
    
    System.Diagnostics.Process excelProcess=null;
    var processes = System.Diagnostics.Process.GetProcesses();
    foreach (var process in processes)
    {
            if (process.Handle.ToInt32() == excel.Hwnd)
                excelProcess = process;
    }
    excelProcess.Exited += new EventHandler(excelProcess_Exited);
