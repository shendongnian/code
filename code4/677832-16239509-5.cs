    string[] commandLineArgs = Environment.GetCommandLineArgs();
    string fileToOpen = null;
    if (commandLineArgs.Length > 1)
    {
        if (File.Exists(commandLineArgs[1]))
        {
            fileToOpen = commandLineArgs[1];
        }
    }
    if (fileToOpen == null)
    {
        // new file
    }
    else
    {
        MyEditor.OpenFile(fileToOpen);
    }
