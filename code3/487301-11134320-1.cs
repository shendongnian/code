    private void TaskSpin(Task<bool> asyncTask, TaskScheduler uiScheduler, 
                          Func<TaskScheduler, object[], bool> asyncMethod, 
                          object[] methodParameters)
    {
        try
        {
            asyncTask = Task.Factory.StartNew<bool>(() => asyncMethod(uiScheduler, methodParameters));
            // Callback for finish/cancellation.
            asyncTask.ContinueWith(task =>
            {
                // Check task status.
                switch (task.Status)
                {
                    // Handle any exceptions to prevent UnobservedTaskException.             
                    case TaskStatus.RanToCompletion:
                        if (asyncTask.Result)
                            UpdateUI(uiScheduler, "OK");
                        else
                        {
                            string strErrComplete = "Process failed.";
                            UpdateUI(uiScheduler, strErrComplete);
                        }
                        break;
                    case TaskStatus.Faulted:
                        string strFatalErr = String.Empty;
                        UpdateUI(uiScheduler, "Fatal Error);
                        if (task.Exception != null)
                            strFatalErr = task.Exception.InnerException.Message;
                        else
                            strFatalErr = "Operation failed";
                        MessageBox.Show(strFatalErr);
                        break;
                }
                asyncTask.Dispose();
                return;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        catch (Exception eX)
        {
            Utils.ErrMsg(eX.Message);
        }
    }
