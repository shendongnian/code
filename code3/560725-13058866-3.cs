    private void DoSomethingToFeed(IFeed feed)
    {
        Task.Factory.StartNew(() => feed.SendData())
            .ContinueWith(_ => Delay(1000 * 60 * 5)
                              .ContinueWith(__ => feed.GetResults())
                         );
    }
    //http://stevenhollidge.blogspot.com/2012/06/async-taskdelay.html
    Task Delay(int milliseconds)      
    {
        var tcs = new TaskCompletionSource<object>();
        new System.Threading.Timer(_ => tcs.SetResult(null)).Change(milliseconds, -1);
        return tcs.Task;
    }
