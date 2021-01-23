    // Prepare the process to run
        ProcessStartInfo start = new ProcessStartInfo();
        // Enter in the command line arguments, everything you would enter after the executable name itself
        start.Arguments = " -";
        // Enter the executable to run, including the complete path
        start.FileName = "doxygen.exe";
        // Do you want to show a console window?
        start.WindowStyle = ProcessWindowStyle.Normal;
        start.CreateNoWindow = false;
        start.RedirectStandardInput = true;
        start.UseShellExecute = false;
    
        // Run the external process & wait for it to finish
        using (Process proc = Process.Start(start))
        {
            //doxygenProperties is just a dictionary
            foreach (string key in doxygenProperties.Keys)
                proc.StandardInput.WriteLine(key+" = "+doxygenProperties[key]);
            proc.StandardInput.Close();
            proc.WaitForExit();
    
            // Retrieve the app's exit code
            int exitCode = proc.ExitCode;
        }
