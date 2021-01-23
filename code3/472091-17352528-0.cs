    void QueryData() 
    {
        var dispatcher = Dispatcher.CurrentDispatcher;
        _dataService.GetData((item, error) =>
        {
            if(error != null)
                return;
            dispatcher.BeginInvoke(new Action(() =>
            {
                foreach(TimeData d in ((LineDetailData)item).Piecesproduced) {
                    Produced.Add(d);
                }
            }), DispatcherPriority.Send);
        });
    }
