    private void CheckBox_CheckChanged(object sender, EventArgs e)
    {
        Task.Factory.StartNew<MyResultData>(DoLongOperation)
                    .ContinueWith(UpdateUI, TaskScheduler.FromCurrentSynchronizationContext());
    }
    private MyResultData DoLongOperation()
    {
        // Long operation
        // Return result to be used to update the UI
        return new MyResultData();
    }
    private void UpdateUI(Task<MyResultData> task)
    {
        // Get the result of the task
        MyResultData data = task.Result;
        // Update the UI using the data
    }
