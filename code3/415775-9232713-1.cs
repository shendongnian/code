    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
         WebGrabber g = new WebGrabber();
    
         g.GetPageElementInnerHTML("http://www.google.com/web/guest/home", "portlet-borderless-container", false);
    
         g.Changed += new ChangedEventHandler(g_Changed);            
    }
    
    void g_Changed(object sender, EventArgs e)
    {
        var html = ((WebGrabber)sender)[0];            
    }
