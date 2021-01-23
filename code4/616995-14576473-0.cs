    private void button1_Click(object sender, EventArgs e)
    {
      Dictionary<string, string> myDict= new Dictionary<string, string>();
      myDict.Add("-subscriptionDataFile", "\"C:\\InstallBox\\asc.publishsettings\"");
      RunPowerShellScript("C:\\InstallBox\\testcode.ps1", myDict);
    }
    internal void RunPowerShellScript(string scriptPath, Dictionary<string, string> arguments)
     {
       RunspaceConfiguration runspaceConfiguration = RunspaceConfiguration.Create();
       Runspace runspace = RunspaceFactory.CreateRunspace(runspaceConfiguration);
       runspace.Open();
       RunspaceInvoke scriptInvoker = new RunspaceInvoke(runspace);
       Pipeline pipeline = runspace.CreatePipeline();
       //Here's how you add a new script with arguments            
       Command myCommand = new Command(scriptPath, true);
       foreach (var argument in arguments)
       {
          myCommand.Parameters.Add(new CommandParameter(argument.Key, argument.Value));
       }
       pipeline.Commands.Add(myCommand);
       var results = pipeline.Invoke();
       foreach (var psObject in results)
        {
           MessageBox.Show(psObject.ToString());
        }
       }
