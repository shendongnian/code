      // Call the PowerShell.Create() method to create an 
      // empty pipeline.
      PowerShell ps = PowerShell.Create();
      // Call the PowerShell.AddCommand(string) method to add 
      // the Get-Process cmdlet to the pipeline. Do 
      // not include spaces before or after the cmdlet name 
      // because that will cause the command to fail.
      ps.AddCommand("Get-Process");
      Console.WriteLine("Process                 Id");
      Console.WriteLine("----------------------------");
      // Call the PowerShell.Invoke() method to run the 
      // commands of the pipeline.
      foreach (PSObject result in ps.Invoke())
      {
        Console.WriteLine(
                "{0,-24}{1}",
                result.Members["ProcessName"].Value,
                result.Members["Id"].Value);
      } 
    } 
