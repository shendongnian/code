    Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
    {  
        try
        {       
            txtReadValue.Value = objRead.Capture();   
        }
        catch { } 
    }
