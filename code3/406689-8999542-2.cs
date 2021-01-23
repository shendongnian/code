    var process = new Process
    {
      StartInfo =
      {
        Arguments = string.Format(@"-display"),
        FileName = configuration.PathToExternalSift,
        RedirectStandardError = true,
        RedirectStandardInput = true,
        RedirectStandardOutput = true,
        UseShellExecute = false,
        CreateNoWindow = true,
      },
      EnableRaisingEvents = true
    };
    process.ErrorDataReceived += (ProcessErrorDataReceived);
    process.Start();
    process.BeginErrorReadLine();
            
    //read in the file.
    using (var fileStream = new StreamReader(configuration.Source))
    {
        fileStream.BaseStream.CopyTo(process.StandardInput.BaseStream);
        process.StandardInput.Close();
    }
    //redirect output to file.
    using (var fileStream = new FileStream(configuration.Destination, FileMode.OpenOrCreate))
    {
        process.StandardOutput.BaseStream.CopyTo(fileStream);
    }
            
    process.WaitForExit();
