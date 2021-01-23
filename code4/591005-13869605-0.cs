    public static TheEventArgs WatchEvent(this InteractionQueue this)
    {
        var ret = Observable.Create<TheEventArgs>(subj => {
            // This entire block gets called every time someone calls Subscribe
            var disp = new CompositeDisposable();
            // Subscribe to the event
            disp.Add(Observable.FromEventPattern(iq, "TheEvent").Subscribe(subj));
            // Stop watching when we're done
            disp.Add(Disposable.Create(() => iq.StopWatching());
            iq.StartWatching();
            // This is what to Dispose on Unsubscribe
            return disp;
        });
        // When > 1 person Subscribes, only call the block above (i.e. StartWatching) once
        return ret.Multicast(new Subject<TheEventArgs>()).RefCount();
    }
