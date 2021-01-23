    private void UserTextBox_GotFocus(object sender, RoutedEventArgs e)
    {
        GeneralTransform gt = MyTextbox.TransformToVisual(Application.Current.RootVisual);
        Point offset = gt.Transform(new Point(0, 0));
        double controlTop = offset.Y;
        double controlLeft = offset.X;
    }
