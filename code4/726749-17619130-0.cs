    base.OnTap(e);
    MyObjectType objectToPass = new MyObjectType();
    PhoneApplicationService.Current.State["myObject"] = objectToPass;
    var frame = Application.Current.RootVisual as PhoneApplicationFrame;
    frame .Navigate(new Uri("/CustomControlProject;component/CustomControlSettings.xaml",
        UriKind.Relative));
    // In destination page's constructor
    public CustomControlSettings() {
      var myObject = (MyObjectType) PhoneApplicationService.Current.State["myObject"];
      // ...
    }
