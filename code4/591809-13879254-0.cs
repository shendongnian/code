    string returnvalue = "";
     
    // Starts the new process as command prompt
    ProcessStartInfo info = new ProcessStartInfo("cmd.exe");
    info.UseShellExecute = false;
    info.RedirectStandardInput = true;
    info.RedirectStandardOutput = true;
    // Makes it so the command prompt window does appear
    info.CreateNoWindow = true;
     
    using (Process process = Process.Start(info))
    {
        StreamWriter sw = process.StandardInput;
        StreamReader sr = process.StandardOutput;
     
        // This for loop could be used if you had a string[] commands where each string in commands
        // is it's own command to write to the prompt. I chose to hardcode mine in.
        //foreach (string command in commands)
        //{
        //    sw.WriteLine(command);
        //}
        sw.WriteLine("cd " + processPath);
        sw.WriteLine("perl process.pl");
     
        sw.Close();
        returnvalue = sr.ReadToEnd();
    }
     
    return returnvalue;
