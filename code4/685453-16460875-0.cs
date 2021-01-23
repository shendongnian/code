    Process[] processes = Process.GetProcessesByName("java");
    var fileteredProcess = from pro in processes
                            where (pro.StartInfo.WorkingDirectory == "workingDIR") &&
                            (pro.StartInfo.Arguments == "Arguments")
                            select pro;
    
    foreach (var proc in fileteredProcess)
    {
    
    }
