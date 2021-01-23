    var ps = PowerShell.Create();
    ps.AddScript(@"Get-ChildItem c:\xyzzy");
    var results = ps.Invoke();
    if (ps.HadErrors)
    {
        foreach (var errorRecord in ps.Streams.Error)
        {
            Console.WriteLine(errorRecord);
        }
    }
    foreach (var result in results)
    {
        Console.WriteLine(result);
    }
