    private void Form1_Load(object sender, EventArgs e)
    {
        var tcs = new TaskCompletionSource<int>();
    
        new Thread(() => {Thread.Sleep(5000); tcs.SetResult(42); }).Start();
    
        Task<int> task = tcs.Task;
        task.ContinueWith(t => MessageBox.Show(t.Result.ToString()));
    }
