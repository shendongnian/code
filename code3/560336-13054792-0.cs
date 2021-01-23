    //This script adds command-line support for MSI build with Visual Studio 2008. 
    var msiOpenDatabaseModeTransact = 1;
    
    if (WScript.Arguments.Length != 1)
    {
        WScript.StdErr.WriteLine(WScript.ScriptName + " file");
        WScript.Quit(1);
    }
    
    WScript.Echo(WScript.Arguments(0));
    var filespec = WScript.Arguments(0);
    var installer = WScript.CreateObject("WindowsInstaller.Installer");
    var database = installer.OpenDatabase(filespec, msiOpenDatabaseModeTransact);
    
    var sql
    var view
    
    try
    {
        //Update InstallUISequence to support command-line parameters in interactive mode.
        sql = "UPDATE InstallUISequence SET Condition = 'QUEUEDIRECTORY=\"\"' WHERE Action = 'CustomTextA_SetProperty_EDIT1'";
        view = database.OpenView(sql);
        view.Execute();
        view.Close();
    
        //Update InstallExecuteSequence to support command line in passive or quiet mode.
        sql = "UPDATE InstallExecuteSequence SET Condition = 'QUEUEDIRECTORY=\"\"' WHERE Action = 'CustomTextA_SetProperty_EDIT1'";
        view = database.OpenView(sql);
        view.Execute();
        view.Close();
    
        database.Commit();
    }
    catch(e)
    {
        WScript.StdErr.WriteLine(e);
        WScript.Quit(1);
    }
