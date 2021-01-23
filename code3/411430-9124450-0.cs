    ProcessStartInfo startInfo = new ProcessStartInfo();
    startInfo.WorkingDirectory = ConfigurationManager.AppSettings.Get("FILE_SAVE_PATH");
    startInfo.FileName = ConfigurationManager.AppSettings.Get("DBF_VIEWER_PATH");
    startInfo.Arguments = string.Format("\"{0}\" /EXPORT:{1} /SEPTAB", filePath, newFilePath);
    using (Process exeProcess = Process.Start(startInfo))
    {
        exeProcess.WaitForExit();
    }
