    // should test for file
    Process nativeProcess = new Process();
    nativeProcess.StartInfo.FileName = filePath;
    try
    {
        nativeProcess.Start();
    }
    catch (Exception Ex)
    {
        // if user cancels on first screen and will throw exception in some situations  
        Debug.WriteLine(Ex.Message);
    }
