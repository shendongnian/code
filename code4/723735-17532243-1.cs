    Task.Factory.StartNew(datasvc.GetItems)
        .ContinueWith( 
            t => 
            {
                BoundList = t.Result;
            }, TaskScheduler.FromCurrentSychronizationContext());
