    foreach (string targetMachine in targetMachines)
    {
        var tcs = new TaskCompletionSource<int>();
        Task.Run(() => { 
            tcs.SetResult(Magic(targetMachine)); 
            return tcs.Task; 
        }).ContinueWith(t => {
            if (t.Result == 2)
            {
                MessageBox.Show("2");
            }
        });
    }
