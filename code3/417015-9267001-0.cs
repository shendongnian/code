    bool? isSleepChecked = null;
    checkBoxSleep.Dispatcher.Invoke(new Action(() =>
    { 
        isSleepChecked = checkBoxSleep.IsChecked; 
    }), 
        DispatcherPriority.Normal);
