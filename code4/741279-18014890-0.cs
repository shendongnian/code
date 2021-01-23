    // Manager class
    public void RequestSomeInfo()
    {
        var task = Task<SomeInfo>.Factory.StartNew(() => bridge.GetSomeInfo());
        task.ContinueWith(t => { OnInfoUpdated(new InfoEventArgs(t.Result)); });
    }
    // Client class
    private string Command(string command)
    {
        lock (pipeName)
        {
            var pipe = new ClientPipe(pipeName);
            pipe.Connect();
            return pipe.Command(command);
        }
    }
