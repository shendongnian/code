    Task sendTask = client.SendAsync(message);
    sendTask.ContinueWith(task => {
        if(task.IsFaulted) {
            Exception ex = task.InnerExceptions.First();
            //handle error
        }
        else if(task.IsCanceled) {
            //handle cancellation
        }
        else {
            //task completed successfully
        }
    });
