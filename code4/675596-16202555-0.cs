    var i = 0;
    _searchService.FindAll()
                  .SubscribeOn(SchedulerSwitch.GetNewThreadScheduler())
                  .Subscribe(i =>
                                 {
                                    i++
                                 }, () =>
                                 {
                                    i*=2; });
