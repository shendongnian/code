    // Construct the path.
    string temp = Environment.GetEnvironmentVariable("temp");
    string path = Path.Combine(temp, "SSCERuntime_x86-ENU.msi");
    
    // Launch the process.
    Process p = new Process();
    p.StartInfo.FileName = path;
    p.StartInfo.Arguments = "/passive";
    p.Start();
