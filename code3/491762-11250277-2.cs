    private Task<int> ProcessAsync(int a, int b, int c)
    {
        var taskCompletionSource = new TaskCompletionSource<int>();
     
        var task = Task.Factory.StartNew<int>(() =>
        {
            // Do your work
     
            return newInt;
        }
        task.ContinueWith(t => taskCompletionSource.SetResult(t.Result));
        return taskCompletionSource.Task;
    }
     
    void Button_Click(object sender, EventArgs args)
    {
        // Disable the button to prevent more clicks
        MyButton.IsEnabled = false;
        var task = ProcessAsync(1,2,3);
        task.ContinueWith(t => 
            {
                 MyTextBox.Content = t.Result;
                 MyButton.IsEnabled = true;
            });
    }
