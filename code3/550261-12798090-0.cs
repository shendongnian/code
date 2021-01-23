    public IObservable<DeviceStatus> GetObservableDeviceStates(TimeSpan silencePeriod)
    {
    	return Observable.Create<DeviceStatus>(
    	o=>
    	{
    		var idle = Observable.Timer(silencePeriod).Select(_=>new DeviceStatus("Idle"));
    	
    		var polledStatus = Observable.Interval(TimeSpan.FromSeconds(0.5))
    						.Select(tick => new DeviceStatus(_device.ReadValue()))
    						.DistinctUntilChanged()
    						.Publish();
    						
    		var subscription = (from status in polledStatus
    					 		from cont in Observable.Return(status).Concat(idle.TakeUntil(polledStatus))
    					 		select cont)
    					 .Subscribe(o);
    		
    		return new CompositeDisposable(subscription, polledStatus.Connect());
    	});
    }
