        process.OutputDataReceived += new DataReceivedEventHandler(process_OutputDataReceived);
    }
    static void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        try
        {
            fullstring.Add(e.Data);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.ToString());
            //log exception
        }
    }
