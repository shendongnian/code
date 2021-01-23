    try
    {
       FTPOperations.ListDirectory(model.configData.FTPInputFolder, model.configData.FTPLogin, model.configData.FTPPassword);
    }
    catch (WebException e)
    {
       FtpWebResponse response = (FtpWebResponse)e.Response;
       if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
       {
          ModelState.AddModelError("configData.FTPInputFolder", "Directory does not exists");
       }
       else
       {
          ModelState.AddModelError("configData.FTPInputFolder", "Directory check error: " + e.Message);
       }
    }
