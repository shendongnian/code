    // write out info to the display window
    private static void shell_OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        string s = e.Data;
    
        if ((s != null) && (shellOut != null))
        {
            SomeOutOrLog(s);         //  output or log the string to somewhere
            shellOut.WriteLine(s);
        }
    }
    private static void shell_ErrorDataReceived(object sender, DataReceivedEventArgs e)
    {
        string s = e.Data;
    
        if (s != null) 
        {
            SomeOutOrLog(s);   //  output or log the string to somewhere
        }
    }
   
