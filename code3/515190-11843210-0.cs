    asyncTask.ContinueWith(task =>
    {
        // Check task status.
        switch (task.Status)
        {
            case TaskStatus.RanToCompletion:
                if (asyncTask.Result)
                {
                    // returned true.
                }
                else
                {
                    // returned false
                }
                break;
            default:
                break;
        }
    }
