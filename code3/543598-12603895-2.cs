    Process p = new Process();
    p.StartInfo.UseShellExecute = false;
    p.StartInfo.RedirectStandardOutput = false;
    p.StartInfo.FileName = "d:/my.bat";
    Console.Write("Running {0} ", p.StartInfo.FileName)
    p.Start();
    while (!p.HasExited)
    {
        Console.Write(".");
        // wait one second
        Thread.Sleep(1000);
    }
    Console.WriteLine(" done.");
    p.Close();
    p.Dispose();
