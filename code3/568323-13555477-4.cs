    PowerShell ps = PowerShell.Create();
    ps.Runspace.SessionStateProxy.SetVariable("a", new int[] { 1, 2, 3 });
    ps.AddScript("$a");
    ps.AddCommand("foreach-object");
    ps.AddParameter("process", ScriptBlock.Create("$_ * 2"));
    Collection<PSObject> results = ps.Invoke();
    foreach (PSObject result in results)
    {
        Console.WriteLine(result);
    }
