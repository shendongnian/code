    public static IObservable<T> ObserveLatestOn<T>(this IObservable<T> source, IScheduler scheduler)
    {
    	return Observable.Create<T>(observer =>
    	{
    		Notification<T> outsideNotification = null;
    		var gate = new object();
    		bool active = false;
    		var cancelable = new MultipleAssignmentDisposable();
    		var disposable = source.Materialize().Subscribe(thisNotification =>
    		{
    			bool alreadyActive;
    			lock (gate)
    			{
    				alreadyActive = active;
    				active = true;
    				outsideNotification = thisNotification;
    			}
    
    			if (!alreadyActive)
    			{
    				cancelable.Disposable = scheduler.Schedule(self =>
    				{
    					Notification<T> localNotification = null;
    					lock (gate)
    					{
    						localNotification = outsideNotification;
    						outsideNotification = null;
    					}
    					localNotification.Accept(observer);
    					bool hasPendingNotification = false;
    					lock (gate)
    					{
    						hasPendingNotification = active = (outsideNotification != null);
    					}
    					if (hasPendingNotification)
    					{
    						self();
    					}
    				});
    			}
    		});
    		return new CompositeDisposable(disposable, cancelable);
    	});
    }
