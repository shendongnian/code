    // Using async version here...
    xcopy.BeginOutputReadLine();
    StreamReader sr = xcopy.StandardOutput;
    while (loop > 0)
    {
        // Trying to use synchronous reading here
        progress = sr.ReadLine();
