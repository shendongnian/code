     BitmapImage image = new BitmapImage(new Uri("/MyApp;component/Images/Backgrounds/myimage.jpg"))
     {
          CreateOptions = System.Windows.Media.Imaging.BitmapCreateOptions.None
     };
     image.ImageOpened += (s, e) =>
     {
          brush.ImageSource = image;
          App.RootFrame.Background = brush;
     };
