    using (Process process = new Process())
    {
        process.StartInfo.FileName = exePath;
        process.StartInfo.Arguments = ""; // args here
        process.Start();
    }
