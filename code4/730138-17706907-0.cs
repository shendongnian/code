    private void Form1_Load(object sender, EventArgs e)
    {
        var tcs = new TaskCompletionSource<int>();
    
        new Thread(() => {Thread.Sleep(5000); tcs.SetResult(42); }).Start();
    
        Task<int> task = tcs.Task;
        Thread.Sleep(2500);
        MessageBox.Show("Waited for 2.5secs on UI thread.");
        MessageBox.Show(task.Result.ToString());
    }
