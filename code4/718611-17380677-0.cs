    private async void btnStart_Click(object sender, EventArgs e)
    {
        await Task.Run(() => MyMethod());
    }
    private void MyMethod()
    {
        Thread.Sleep(5000);
    }
