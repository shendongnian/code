    using System.Collections.ObjectModel;
    using System.Management.Automation;
    using System.Management.Automation.Runspaces;
    
    private static Boolean alreadySigned(string file)
    {            
                try
                {
                    RunspaceConfiguration runspaceConfiguration = RunspaceConfiguration.Create();
                    Runspace runspace = RunspaceFactory.CreateRunspace(runspaceConfiguration);
                    runspace.Open();
    
                    Pipeline pipeline = runspace.CreatePipeline();
                    pipeline.Commands.AddScript("Get-AuthenticodeSignature \"" + file + "\"");
    
                    Collection<PSObject> results = pipeline.Invoke();
                    runspace.Close();
                    Signature signature = results[0].BaseObject as Signature;
                    return signature == null ? false : (signature.Status != SignatureStatus.NotSigned);
                }
                catch (Exception e)
                {
                    throw new Exception("Error when trying to check if file is signed:" + file + " --> " + e.Message);
                }
    }
