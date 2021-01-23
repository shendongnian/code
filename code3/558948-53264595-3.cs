    public string SyncMethod(object parameter)  
    {
        var sender = CurrentPage as MainView; // interop
        var result = string.Empty;
        
        if (sender != null)
        {
            await sender.Dispatcher.Invoke(DispatcherPriority.Normal,
                new Func<Task>(async () =>
                {
                    try
                    {
                        result = await sender.AsyncMethod(parameter.ToString());
                    }
                    catch (Exception exception)
                    {
                        result = exception.Message;
                    }
                }));
        }
        await Task.Delay(200); // <-- Here
        return result;        
    }
