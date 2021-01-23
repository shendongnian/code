    private  void DownloadStringCallback2(Object sender, DownloadStringCompletedEventArgs e)
    {
        if (e.Error != null)
        {
            // Check the error here
        }
        // If the request was not canceled and did not throw
        // an exception, display the resource.
        else if (!e.Cancelled)
        {
            output.Text= (string)e.Result;
            //If you get the cross-thread exception then use the following line instead of the above
            //Dispatcher.BeginInvoke(new Action (() => textBlock1.Text = (string)e.Result));
        }
    }
