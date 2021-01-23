class OpenXmlPowerTools
{
    static string SCRIPT_PATH = @"..\MergeDocuments.ps1";
    public static void UsingPowerShell(string[] filesToMerge, string outputFilename)
    {
        // create Powershell runspace
        Runspace runspace = RunspaceFactory.CreateRunspace();
        runspace.Open();
        RunspaceInvoke runSpaceInvoker = new RunspaceInvoke(runspace);
        runSpaceInvoker.Invoke("Set-ExecutionPolicy Unrestricted");
        // create a pipeline and feed it the script text
        Pipeline pipeline = runspace.CreatePipeline();
        Command command = new Command(SCRIPT_PATH);
        foreach (var file in filesToMerge)
        {
            command.Parameters.Add(null, file);
        }
        command.Parameters.Add(null, outputFilename);
        pipeline.Commands.Add(command);
        pipeline.Invoke();
        runspace.Close();
    }
}
