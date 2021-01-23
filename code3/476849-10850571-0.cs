    protected override void OnStartup(StartupEventArgs e)
    {
      // Get the width and height, you might want to at least round these to a few values.
      var width = System.Windows.SystemParameters.PrimaryScreenWidth;
      var height = System.Windows.SystemParameters.PrimaryScreenHeight;
    
      // make the resource path from them.
      string resourceName = string.Format("Themes\resource{0}x{1}", width, height);
    
      // Add the resource to the app.
      Application.Current.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(resourceName, UriKind.Relative)));
    
      base.OnStartup(e);
    }
