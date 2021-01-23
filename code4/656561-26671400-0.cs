    var psi = new ProcessStartInfo(@"C:\Program Files (x86)\Git\bin\git.exe", "push " + remoteUrl + " " + branch)
    {
        UseShellExecute = false,
        RedirectStandardOutput = true,
        RedirectStandardError = true
    };
    var process = new Process
    {
        StartInfo = psi
    };
    Console.WriteLine("Pushing...");
    process.Start();
    var stdOutTask = Task.Factory.StartNew(() =>
    {
        string str;
        while ((str = process.StandardOutput.ReadLine()) != null)
        {
            Console.WriteLine(str);
        }
    });
    var stdErrorTask = Task.Factory.StartNew(() =>
    {
        string str;
        while ((str = process.StandardError.ReadLine()) != null)
        {
            Console.WriteLine(str);
        }
    });
    stdOutTask.Wait();
    stdErrorTask.Wait();
    process.WaitForExit();
    process.Close();
