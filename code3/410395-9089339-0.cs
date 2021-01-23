    var observable =
        Observable.FromEventPattern<MapEventArgs>(
            handler => map.ViewChangeEnd += handler,
            handler => map.ViewChangeEnd -= handler);
    
    observable.Throttle(TimeSpan.FromSeconds(1))
              .Subscribe(ev => map_ViewChangeEnd(ev.Sender, ev.EventArgs));
    ...
    void map_ViewChangeEnd(object sender, MapEventArgs e)
    {
        ...
    }
