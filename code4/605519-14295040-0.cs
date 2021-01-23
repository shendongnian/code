    public IObservable<DigitalInputHeldInfo> Adapt(
      IObservable<EventPattern<AdsNotificationEventArgs>> messageStream) {
      var startObservable = _digitalInputPressedEventAdapter.
          Adapt(messageStream).
          Publish();
      var endObservable = _digitalInputReleasedEventAdapter.
          Adapt(messageStream).
          Publish();
      startObservable.Connect();
      endObservable.Connect();
      return from notification in startObservable.Timestamp()
             from interval in Observable.Interval(500.Milliseconds(), 
                                                  _schedulerProvider.ThreadPool).
                              Timestamp().
                              TakeUntil(endObservable)
             select new DigitalInputHeldInfo(
                    interval.Timestamp.Subtract(notification.Timestamp), 
                    notification.Value);
    }
