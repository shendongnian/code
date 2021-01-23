    string output = null;
    try
    {
        ProcessStartInfo ps = new ProcessStartInfo("cmd");
        ps.Arguments = "/c cd.."; 
        ps.UseShellExecute = false;
        // Redirects the standard output so it reads internally in out program
        ps.RedirectStandardOutput = true;
        // Starts the process
        using (Process p = Process.Start(ps))
        {
            // Reads the output to a string
            output = p.StandardOutput.ReadToEnd();
            // Waits for the process to exit must come *after* StandardOutput is "empty"
            // so that we don't deadlock because the intermediate kernel pipe is full.
            p.WaitForExit();
        }
    }
    catch
    {
        // manage errors
    }
    finally
    {
	if(output != null)
	{
	     // Process your output
	}
    }
