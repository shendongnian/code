    async private Task CountToTen()
    {
       return Task.Factory.StartNew(() =>
            {
                for (var i = 1; i <= 10; i++)
                {
                    Seconds.Text = i.ToString(CultureInfo.InvariantCulture);
                    //Task.Delay(1000).Wait();
                    await Task.Delay(1000);
                }
            }, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
    }
