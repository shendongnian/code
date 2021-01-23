    private void TryToUpdateButtonCheckAccess(object uiObject)
    {
        Button theButton = uiObject as Button;
    
        if (theButton != null)
        {
            // Checking if this thread has access to the object
            if(theButton.CheckAccess())
            {
                // This thread has access so it can update the UI thread
                UpdateButtonUI(theButton);
            }
            else
            {
                // This thread does not have access to the UI thread
                // Pushing update method on the Dispatcher of the UI thread
                theButton.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new UpdateUIDelegate(UpdateButtonUI), theButton);
            }
        }
    }
