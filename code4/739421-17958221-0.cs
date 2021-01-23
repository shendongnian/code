    var t = Task.Factory.StartNew<bool>(() => { throw new Exception("aaa"); });
       try
       {
         t.ContinueWith(_ => {}, TaskContinuationOptions.OnlyOnRanToCompletion)
            .Wait();
       }
       catch (AggregateException exc)
       {
         Debug.WriteLine(exc.InnerExceptions[0]);// "A task was canceled"
         Debug.WriteLine(t.Exception.InnerExceptions[0]);// "aaa"
       }
