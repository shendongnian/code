    string finalFileName = "myAmplifiedFile.WAV";
    string tmpFileName = "tmpHoldingFile.WAV";
    string soxEXE = @"C:\SOX\sox.exe";
    string soxArgs = "-v 3.0 ";
    /// OTHER STUFF HERE 
    /*-----------------------------------------------------------
    * Call the SOX utility to amplify it so it is 3 times as loud.
    *-----------------------------------------------------------*/
    try
    {
        System.Diagnostics.Process process = new System.Diagnostics.Process();
        process.StartInfo = new System.Diagnostics.ProcessStartInfo();
        process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        process.StartInfo.FileName = soxEXE;
        process.StartInfo.Arguments = string.Format("{0} {1} {2}",
                                 soxArgs, tmpFileName, finalFileName);
        process.Start();
        process.WaitForExit();
        int exitCode = process.ExitCode;
    }
    catch (Exception ex)
    {
        string err = ex.Message;
        return false;
    }
    /*-------------------------------------------------------------
     * OK, now we play it using SoundPlayer
     *-------------------------------------------------------------*/
    try
    {
        SoundPlayer simpleSound = new SoundPlayer(@finalFileName);
        simpleSound.PlaySync();
        FileInfo readFile = new FileInfo(finalFileName);
        string finalDestination = finalDirectory + "/" + readFile.Name;
        readFile.MoveTo(finalDestination);
    }
    catch (Exception e)
    {
        string errmsg = e.Message;
        return false;
    }
    finalFileName = "";
    tmpFileName = "";
    spVoice = null;
