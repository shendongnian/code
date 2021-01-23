    string result;
    Process p = new Process();
    p.StartInfo.FileName = "netsh.exe";
    p.StartInfo.Arguments = "interface ip add address name=\"Local Area Connection\" static 192.168.1.191 255.255.255";
    p.StartInfo.UseShellExecute = false;
    p.StartInfo.CreateNoWindow = true;
    p.StartInfo.RedirectStandardOutput = true;
    try
    {
       p.Start();
       p.WaitForExit(30000);
       result = p.StandardOutput.ReadToEnd();
    }
    catch(Exception ex)
    {
       result = ex.Message;
    }
    // check "result" variable for your results.
