    Task.Factory
        .StartNew(() => GetData())
        .ContinueWith(t => 
        {
            gvShowResult.DataSource = t.Result; 
            gvShowResult.DataBind();
            UpdatePanel2.Update();
        }, TaskScheduler.FromCurrentSynchronizationContext());
