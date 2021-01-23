    System.Threading.Tasks.Task.Factory.StartNew(
                                            () => AddAttachment(document, docId, user)).ContinueWith(
                                                task => OnComplete(task), }
                                                TaskContinuationOptions.None);  
    private void OnComplete(task)
    {
       if(task.IsFaulted)
       {
       }
       else if(task.IsComplete {}
    }
