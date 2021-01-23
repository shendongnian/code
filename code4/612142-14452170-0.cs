    Deployment.Current.Dispatcher.BeginInvoke(() =>
    {
        System.Windows.Media.Imaging.BitmapImage b = 
            new System.Windows.Media.Imaging.BitmapImage(new Uri(@"cat.jpg",         
            UriKind.RelativeOrAbsolute));
    
    });
