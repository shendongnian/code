    Process process = new Process();
    
    process.StartInfo.FileName = pathToPdfOrDocFile; 
    process.UseShellExecute = true;
    process.StartInfo.Verb = "printto";
    process.StartInfo.Arguments = "\"" + printerName + "\""; 
    process.Start();
    
    process.WaitForInputIdle();
    process.Kill();
