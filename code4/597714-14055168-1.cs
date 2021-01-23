    ProcessStartInfo psi = new ProcessStartInfo();
    psi.FileName = "cmd";
    psi.Arguments = "/c \"phantomjs -v\"";
    psi.UseShellExecute = false;
    psi.RedirectStandardOutput = true;
    // Optional other options
    Process proc = Process.Start(psi);
    string output = proc.StandardOutput.ReadToEnd();
    proc.WaitForExit();
