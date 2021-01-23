    private List<IObserver<Location>> observers;
    
    public IDisposable Subscribe(IObserver<Location> observer) 
    {
       if (! observers.Contains(observer)) 
          observers.Add(observer);
       // ------- If observers.Count == 1 create connection. -------
       return new Unsubscriber(observers, observer);
    }
    private class Unsubscriber : IDisposable
    {
       private List<IObserver<Location>>_observers;
       private IObserver<Location> _observer;
    
       public Unsubscriber(List<IObserver<Location>> observers, IObserver<Location> observer)
       {
          this._observers = observers;
          this._observer = observer;
       }
    
       public void Dispose()
       {
          if (_observer != null && _observers.Contains(_observer))
             _observers.Remove(_observer);
          // ----------- if observers.Count == 0 close connection -----------
       }
    }
