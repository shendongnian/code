        public void GetItemsAsync(Action<Item[]> handleResult)
        {
            Task task = Task.Factory.StartNew<Item[]>(() =>
            {
                return this.CreateItems(); // May take a second or two
            });
            task.ContinueWith(delegate
            {
                handleResult(task.Result);
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
