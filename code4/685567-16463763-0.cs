    var proc = System.Diagnostics.Process.Start("regsvr32", "msxml6.dll /s");
    proc.WaitForExit();
    Console.WriteLine(proc.ExitCode);
    proc = System.Diagnostics.Process.Start("regasm", name+" /silent");
    proc.WaitForExit();
    Console.WriteLine(proc.ExitCode);
