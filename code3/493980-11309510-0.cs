    private static void SetAppBackground(string imageName) 
        {
          var app = Application.Current as App;
          if (app == null)
            return;
    
          var imageBrush = new ImageBrush
                     {
                       ImageSource = new BitmapImage(new Uri(imageName, UriKind.Relative))
                     };
          app.RootFrame.Background = imageBrush;
        }
