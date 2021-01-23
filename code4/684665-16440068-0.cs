        var tokenSource2 = new CancellationTokenSource();
        CancellationToken ct = tokenSource2.Token;
        var task = Task.Factory.StartNew(() =>
        {
            ct.ThrowIfCancellationRequested();
            var result = Database.GetResult(); // whatever database query method you use.
            ct.ThrowIfCancellationRequested();
            return result;
        }, tokenSource2.Token);
