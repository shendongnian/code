    // Code to execute when the application is launching (eg, from Start)
    // This code will not execute when the application is reactivated
    private void Application_Launching(object sender, LaunchingEventArgs e)
    {
        ImageBrush brush = new ImageBrush
        {
            ImageSource = new System.Windows.Media.Imaging.BitmapImage(new Uri("/Images/AppBackground.jpg", UriKind.Relative)),
            Opacity = 0.5d
        };
        this.RootFrame.Background = brush;
    }
