    FileIOPermission permFileIO =
    new FileIOPermission(FileIOPermissionAccess.AllAccess, "C:\\Temp");
    try 
    {
        // Demand the permission to access the C:\Temp folder.
        permFileIO.Demand();
        resultText.Append("The demand for permission to access the C:\\Temp folder succeeded.\n\n");
    }
    catch (SecurityException se)
    {
        resultText.Append("The demand for permission to access the C:\\Temp folder failed.\nException message: ");
        resultText.Append(se.Message);
        resultText.Append("\n\n");
    }
