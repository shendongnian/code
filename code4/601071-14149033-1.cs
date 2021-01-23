    protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
    {
        base.OnBackKeyPress(e);
        if (!isPerformingCloseOperation) 
        {
            if (history.Count > 0)
            {                        
                Uri destination = history.Peek();
                webBrowser.Navigate(destination);
                // What about using script and going history.back? 
                // you can do it, but 
                // I rather use that to keep ‘track’ consistently with our stack 
                e.Cancel = true;
            }
        } 
    }
