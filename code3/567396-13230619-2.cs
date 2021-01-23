        public void HeavyLifting(Action<List<Items>> callback)
        {
            Task<List<Items>> task = Task.Factory.StartNew(
                () =>
                    {
                        var myResults = new List<Items>();
                        // do the heavy stuff.
                        return myResults;
                    });
            callback.Invoke(task.Result);
        }
