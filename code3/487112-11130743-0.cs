    try
    {
        FileIOPermission perf = new FileIOPermission(FileIOPermissionAccess.Read, @"C:\Users\jbeaulac\Documents\test.xml");
        perf.Demand();
    }
    catch (Exception ex)
    {
        MessageBox.Show("Not enough permission, blah blah blah.");
        return;
    }
         
    var reader = XmlReader.Create(@"C:\Users\jbeaulac\Documents\test.xml");
    /// ...
