    public void b_DownloadStringCompleted(Object sender, DownloadStringCompletedEventArgs e) 
    { 
        string testMatch = ""; 
  
        if(!e.Cancelled && e.Error == null) 
        { 
            string str; 
            // Size the control to fill the form with a margin 
            str = (string)e.Result; 
 
            //Various operations and parsing 
            Top newTop = new Top(testMatch,(place.Count+1));
 
            Dispatcher.Invoke(() =>
            {
                top.Add(newTop);
            });
        } 
    } 
