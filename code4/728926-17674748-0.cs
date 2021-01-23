    var info = new ProcessStartInfo("msbuild")
    {
        UseShellExecute = false,
        CreateNoWindow = true,
        RedirectStandardError = true,
        RedirectStandardOutput = true,            
    };
    using (var p = Process.Start(info) )
    {
        p.ErrorDataReceived += (s, e) => Console.Error.WriteLine(e.Data);
        p.OutputDataReceived += (s, e) => Console.WriteLine(e.Data);
        p.BeginErrorReadLine();
        p.BeginOutputReadLine();
        p.WaitForExit();
    }
