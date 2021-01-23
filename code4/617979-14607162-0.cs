    public T ExecuteSync<T>(Func<Task<T>> function) {
                return new TaskFactory(TaskScheduler.Default).StartNew((t) => function().Result, TaskContinuationOptions.None).Result; ;
            }
    private void button2_Click(object sender, EventArgs e)
    {
        var client = GetClient(true);
        var response = ExecuteSync(() => PostUsingClient(client));
    }
