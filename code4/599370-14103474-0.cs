    // Use LoginCompletedEventArgs, or whatever type you need out of the .loginCompleted event
    public static Task<LoginCompletedEventArgs> LoginAsyncTask(this YChatWebService.WebServiceControllerPortTypeClient client, string userName, string password) 
    { 
        var tcs = CreateSource<LoginCompletedEventArgs>(address); 
        client.loginCompleted += 
            (sender, e) => TransferCompletion(tcs, e, e, null); 
        client.loginAsync(userName, password);
        return tcs.Task; 
    }
    
    private static TaskCompletionSource<T> CreateSource<T>(object state) 
    { 
        return new TaskCompletionSource<T>( 
            state, TaskCreationOptions.DetachedFromParent); 
    }
    
    private static void TransferCompletion<T>( 
        TaskCompletionSource<T> tcs, AsyncCompletedEventArgs e, 
        Func<T> getResult, Action unregisterHandler) 
    { 
        if (e.UserState == tcs) 
        { 
            if (e.Cancelled) tcs.TrySetCanceled(); 
            else if (e.Error != null) tcs.TrySetException(e.Error); 
            else tcs.TrySetResult(getResult()); 
            if (unregisterHandler != null) unregisterHandler();
        } 
    }
