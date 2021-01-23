    public static void OnCurrentReadingChanged(DependencyObject doj, DependencyPropertyChangedEventArgs dp) 
    { 
        var myObject = (RadarView)doj;
        if (myObject.IsStartMode) 
            myObject.Start(); 
        else 
            myObject.Stop(); 
    } 
