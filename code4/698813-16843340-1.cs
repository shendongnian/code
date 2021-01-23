                Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    var myHost = ObjectFactory.GetInstance<MyHost>();
                    myHost.SendMessage();
                    Thread.Sleep(3000);
                }
            })
            .ContinueWith(t => { throw new Exception("The task threw an exception", t.Exception); }, TaskContinuationOptions.OnlyOnFaulted);
