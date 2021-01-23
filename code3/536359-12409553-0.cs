    using System.Collections.ObjectModel;
    using System.Management.Automation;
    using System.Management.Automation.Runspaces;
    .
    .
    .
    MAIN CODE:
    Runspace runspace = RunspaceFactory.CreateRunspace();
    runspace.Open();
    PowerShell ps = PowerShell.Create();
    ps.AddScript("Add-PsSnapin Microsoft.SharePoint.Powershell");
    ps.AddScript("get-spfarm | select BuildVersion");
    ps.AddCommand("Out-String");
    Collection <PSObject> results = ps.Invoke();
    runspace.Close();
    foreach (PSObject obj in results)
    {
        Console.WriteLine(obj.ToString());
    }
    
