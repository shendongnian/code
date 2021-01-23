    var cts = new CancellationTokenSource();
    var task = new Task(YourLongRunningOperation, cts.Token);
    task.Start();
    
    var delayTask = Task.Delay(5000);
    
    try
    {
        await Task.WhenAny(task, delayTask);
        if(!task.IsCompleted)
        {
            cts.Cancel();
            // You can display a message here.
            await task;
        }
    }
    catch(OperationCanceledException cex)
    {
        // TODO Handle cancelation.
    }
    catch (AggregateException aex)
    {
        // TODO Handle exceptions.
    }
    
    if(task.IsCanceled && delayTask.IsCompleted)
    {
        // TODO Display a long running error message.
    }
