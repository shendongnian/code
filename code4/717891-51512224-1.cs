    string packagesFolder = Dts.Variables["User::packagesFolder"].Value.ToString();
    string rootFolder = Dts.Variables["User::rootFolder"].Value.ToString();
    
    Package pkg;
    Microsoft.SqlServer.Dts.Runtime.Application app;
    DTSExecResult pkgResults;
    
    foreach (var pkgLocation in Directory.EnumerateFiles(packagesFolder+"\\", "ValidateDataMigration-*.dtsx"))
    {
        try
        {
            app = new Microsoft.SqlServer.Dts.Runtime.Application();
            pkg = app.LoadPackage(pkgLocation, null);
            pkgResults = pkg.Execute();
    
            File.AppendAllText(rootFolder + "\\DataValidationProgress.log", pkgLocation.ToString()+"=>"+ pkgResults.ToString()+ Environment.NewLine);
        }
        catch(Exception e)
        {
            File.AppendAllLines(rootFolder + "\\DataValidationErrors.log", new string[] { e.Message, e.StackTrace });
        }
    }
