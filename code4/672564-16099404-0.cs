    if(currentWindow != null)
        {
            if(currentWindow.CheckAccess()) {
              currentWindow.Close();
            }
            else {
              currentWindow.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                ()=>{currentWindow.Close();},null);
            }
            if (targetWindow.CheckAccess()) {
                targetWindow.Show();
              }
            else {
                targetWindow.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                ()=>{targetWindow.Show();},null);
            }
            
        }
