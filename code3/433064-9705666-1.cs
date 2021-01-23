    public Task<double> DefineTaskContinuation(Task<double> _task)
    {
        _task.ContinueWith(i =>
            {
                textBox2.Text = (i.Result + 2).ToString();
                return i.Result + 2;
            }, TaskScheduler.FromCurrentSynchronizationContext())
        .ContinueWith(i =>
            {
                textBox3.Text = (i.Result + 2).ToString();
            }, TaskScheduler.FromCurrentSynchronizationContext());
         return _task;
    }
