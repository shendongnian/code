    protected override void OnInvoke(ScheduledTask task)
    {
       Deployment.Current.Dispatcher.BeginInvoke(() =>
          {
              img = new BitmapImage(new Uri(imgLoc, UriKind.Absolute));
              img.CreateOptions = BitmapCreateOptions.None;
              img.ImageOpened += img_ImageOpened;
          });
    }
