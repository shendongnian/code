    var context = SynchronizationContext.Current;
    var tm = new System.Threading.Timer(state => 
    {
      context.Send(delegate() { statusDateTimeLabel.Text = DateTime.Now.ToLocalTime().ToString(CultureInfo.InvariantCulture); });
    }, null, TimeSpan.FromMilliseconds(0), TimeSpan.FromMilliseconds(1000));
