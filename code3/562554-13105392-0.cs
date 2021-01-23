    var mouseDowns = Observable.FromEventPattern
        <MouseEventHandler, MouseEventArgs>(
            h => this.MouseDown += h,
            h => this.MouseDown -= h);
    var mouseUps = Observable.FromEventPattern
        <MouseEventHandler, MouseEventArgs>(
            h => this.MouseUp += h,
            h => this.MouseUp -= h);
    var intervals = Observable.Interval(TimeSpan.FromSeconds(0.1));
    var query =
        from md in mouseDowns
        select intervals.TakeUntil(mouseUps);
    query.Switch().ObserveOn(this).Subscribe(n => numericUpDown1.Value += 1);
