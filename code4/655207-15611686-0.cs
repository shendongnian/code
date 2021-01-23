    asyncTask.ContinueWith(task =>
    {
        // Check task status.
        switch (task.Status)
        {
            // Handle any exceptions to prevent UnobservedTaskException.             
            case TaskStatus.RanToCompletion:
                if (asyncTask.Result)
                {
                    // Do stuff...
                }
                break;
            case TaskStatus.Faulted:
                if (task.Exception != null)
                    mainForm.progressRightLabelText = task.Exception.InnerException.Message;
                else
                    mainForm.progressRightLabelText = "Operation failed!";
            default:
                break;
        }
    }
