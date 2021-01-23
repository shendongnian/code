    Process process = new Process();
    process.StartInfo.FileName = "your_application.exe";
    process.StartInfo.Arguments = "argument1 argument2 argument2 ...";
    process.StartInfo.UseShellExecute = false;
    process.StartInfo.RedirectStandardOutput = true;
    process.Start();    
    
    Console.WriteLine(process.StandardOutput.ReadToEnd());
    
    process.WaitForExit();
