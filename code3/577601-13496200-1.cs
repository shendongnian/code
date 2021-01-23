    public static Task WhenClosed(this Form form)
    {
        var tcs = new TaskCompletionSource<object>();
    
        form.FormClosing += (_, args) =>
        {
            tcs.SetResult(null);
        };
    
        return tcs.Task;
    }
