    System.Diagnostics.Process process = null;
    System.Diagnostics.ProcessStartInfo processStartInfo;
    
    processStartInfo = new System.Diagnostics.ProcessStartInfo();
    
    processStartInfo.FileName = "regedit.exe";
    
    if (System.Environment.OSVersion.Version.Major >= 6)  // Windows Vista or higher
    {
       processStartInfo.Verb = "runas";
    }
    else
    {
       // No need to prompt to run as admin
    }
    
    processStartInfo.Arguments = "";
    processStartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
    processStartInfo.UseShellExecute = true;
    
    try
    {
       process = System.Diagnostics.Process.Start(processStartInfo);
    }
    catch (Exception ex)
    {
       MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    finally
    {
       if (process != null)
       {
          process.Dispose();
       }
    }
