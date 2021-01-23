    using System.Reactive.Concurrency;
    using System.Reactive.Linq;
    var observable = Observable.FromEventPattern<MapEventArgs>(
                        handler => MyMap.ViewChangeEnd += handler,
                        handler => MyMap.ViewChangeEnd -= handler);
    observable.Throttle(TimeSpan.FromSeconds(2)).ObserveOn(DispatcherScheduler.Current).Subscribe(ev => MyMap_ViewChangeEnd(ev.Sender, ev.EventArgs)); 
