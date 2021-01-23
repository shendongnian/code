    private void button1_Click(object sender, EventArgs e)
    {
        var ui = TaskScheduler.FromCurrentSynchronizationContext();
        Task<List<T>> task = Task.Factory.StartNew(() => MyTaskWorker());
        task.ContinueWith(t => OnMyTaskCompleted(t), ui);
    }
    private List<T> MyTaskWorker()
    {
        // here I populate the list. I emulate this with a sleep of 3 seconds
        Thread.Sleep(3000);
        return ...;
    }
    protected virtual void OnMyTaskCompleted(Task t)
    {
        // here I'll populate the textbox with t.Result
        textBox1.Text = "... content of the Iteration on the List...";
    }
