    public void Application_EndRequest(object src, EventArgs e)
    {
        DateTime end = (DateTime)Context.Items["loadstarttime"];
        TimeSpan ts = DateTime.Now - end;
        // Format and display the TimeSpan value. 
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
        Response.Write("<div style='text-align: center' class='thesmallprint'>Page loaded in: " + elapsedTime + "</div>");
    }
