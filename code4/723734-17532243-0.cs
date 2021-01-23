    Task.Factory.StartNew<IEnumerable<DataModel.Item>>(datasvc.GetItems)
        .ContinueWith( 
            t => 
            {
                BoundList = t.Result;
            }, TaskScheduler.FromCurrentSychronizationContext());
