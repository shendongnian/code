      private static SecurityIdentifier UserSID(string username)
      {
         var f = new NTAccount(username);
         return (SecurityIdentifier)f.Translate(typeof(SecurityIdentifier));
      }
      private string PsCmdAddSite(Uri url, bool allow)
      {
         return string.Format(
    @"$o = ([WMIClass] ""root\CIMV2\Applications\WindowsParentalControls:WpcURLOverride"").CreateInstance()
    $o.Allowed = {0}
    $o.URL = ""{1}""
    $o.SID = ""{2}""
    $o.Put()", (allow ? "1" : "2"), url, UserSID('TargetUsername'));
      }
      private static string PsCmdRemoveAllSites()
      {
         return
    @"$allSites = Get-WmiObject -Class WpcURLOverride -Namespace root/CIMV2/Applications/WindowsParentalControls;
    foreach ($site in $allSites){Remove-WmiObject -InputObject $site;}";
      }
      private static void RunPsScript( string scriptText )
      {
         // create Powershell runspace, logically a single PS session
         Runspace runspace = RunspaceFactory.CreateRunspace();
         runspace.Open();
         // create a pipeline and feed the script text
         Pipeline pipeline = runspace.CreatePipeline();
         pipeline.Commands.AddScript(scriptText);
         pipeline.Commands.Add("Out-String");
         // execute the script
         pipeline.Invoke();
         runspace.Close();
      }
      
