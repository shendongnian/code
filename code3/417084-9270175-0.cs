    {
     // say GetState returns 2
     var state = GetState(); 
     // state now = 2
     Dispatcher.BeginInvoke(() => StateChanged(state)); 
     state = 3; 
    }
