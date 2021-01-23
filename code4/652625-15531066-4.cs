    IAsyncResult OnBeginAsync(object sender, EventArgs e, 
                              AsyncCallback cb, object extraData)
    {
        HttpContext context = ((HttpApplication)sender).Context;
        EnqueueDelegate enqueueDelegate = new EnqueueDelegate(ProcessImage);
        return enqueueDelegate.BeginInvoke(context, cb, extraData);
    }
    public void OnEndAsync(IAsyncResult result)
    {
        // Ensure our ProcessImage has completed in the background.
        while (!result.IsComplete)
        {
            System.Threading.Thread.Sleep(1); 
        }
    }
