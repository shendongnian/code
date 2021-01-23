    protected void Application_Error(object sender, EventArgs e)
    {
        // Get error and log objects
        var exception = Server.GetLastError();
        var log = new System.IO.StreamWriter("c:\\path\\to\\log.txt");
    
        // Write out what you need and close the file
        log.WriteLine(exception.Message);
        log.Close();
    
        // Redirect to error page ..
    }
