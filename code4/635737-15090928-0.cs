        process.StartInfo.RedirectStandardOutput = true;
        process.OutputDataReceived += 
            new DataReceivedEventHandler(process_OutputDataReceived);
    
        process.StartInfo.RedirectStandardError = true;
        process.ErrorDataReceived += 
            new DataReceivedEventHandler(process_ErrorDataReceived);
        if (process.Start())
        {
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
        }
    }
    void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        Console.WriteLine(e.Data);
    }
    void process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
    {
        Console.WriteLine(e.Data);
    }
