    if (System.IO.File.Exists(fileToOpen))
    {
        Process.Start(fileToOpen);
    }
    else
    {
        // handle missing file scenario
    }
