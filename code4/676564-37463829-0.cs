    [CommandMethod("ConnectToAcad")]
    public static void ConnectToAcad()
    {
        AcadApplication acAppComObj = null;
        const string strProgId = "AutoCAD.Application.18";
        // Get a running instance of AutoCAD
        try
        {
            acAppComObj = (AcadApplication)Marshal.GetActiveObject(strProgId);
        }
        catch // An error occurs if no instance is running
        {
            try
            {
                // Create a new instance of AutoCAD
                acAppComObj = (AcadApplication)Activator.CreateInstance(Type.GetTypeFromProgID(strProgId), true);
            }
            catch
            {
                // If an instance of AutoCAD is not created then message and exit
                System.Windows.Forms.MessageBox.Show("Instance of 'AutoCAD.Application'" +
                                                     " could not be created.");
                return;
            }
        }
        // Display the application and return the name and version
        acAppComObj.Visible = true;
        System.Windows.Forms.MessageBox.Show("Now running " + acAppComObj.Name +
                                             " version " + acAppComObj.Version);
        // Get the active document
        AcadDocument acDocComObj;
        acDocComObj = acAppComObj.ActiveDocument;
        // Optionally, load your assembly and start your command or if your assembly
        // is demandloaded, simply start the command of your in-process assembly.
        acDocComObj.SendCommand("(command " + (char)34 + "NETLOAD" + (char)34 + " " +
                                (char)34 + "c:/myapps/mycommands.dll" + (char)34 + ") ");
        acDocComObj.SendCommand("MyCommand ");
    }
