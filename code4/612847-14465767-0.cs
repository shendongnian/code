    Task.WaitAll(
        Task.Factory.StartNew(() =>
        {
            Thread.Sleep(1000);
        }),
        Task.Factory.StartNew(() => { Thread.Sleep(1000); }),
        Task.Factory.StartNew(() => { Thread.Sleep(1000); })
        );
