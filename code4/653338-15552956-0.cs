    private SerialDisposable _timerSubscription = new SerialDisposable();
    AddItem(string item)
    {
      _mySet.Add(item);
      var timer = Observable.Timer(TimeSpan.FromSeconds(60), _scheduler);
      // A SerialDisposable works like this:
      //      when you set its Disposable, if it already has one, it will 
      //      auto-dispose the last value and set the new value
      _timerSubscription.Disposable = timer
          .Take(1)
          .Do(item => RemoveItem(item))
          .Subscribe(_ => Console.WriteLine("Removed {0}", item));
    }
    public void Dispose()
    {
        if(_timerSubscription != null && _timerSubscription.Disposable != null)
        {
            _timerSubscription.Dispose();
        }
    }
