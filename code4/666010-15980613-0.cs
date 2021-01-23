        ProcessInfo.RedirectStandardOutput = true;
        ProcessInfo.RedirectStandardError = true;
		// (...)
        Process.WaitForExit();
        string stderr = Process.StandardError.ReadToEnd();
        string stdout = Process.StandardOutput.ReadToEnd();
        Console.WriteLine("STDERR: " + stderr);
        Console.WriteLine("STDOUT: " + stdout);
