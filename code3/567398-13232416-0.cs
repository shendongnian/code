    Task.Factory.StartNew(() => 
    {
        var theTvdb = new TheTVDB();
        var dexterSeries = theTvdb.SearchSeries("Dexter");
        Application.Current.Dispatcher.Invoke(new Action(() => 
        {    
            foreach (var tvSeries in dexterSeries)
            {
                this.Overview.Add(tvSeries);
            }
        }));
    });
