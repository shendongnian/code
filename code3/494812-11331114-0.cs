        Point point = MyControl.PointToScreen(new Point((MyControl.ActualWidth / 2)
                                                              , MyControl.ActualHeight));
        PresentationSource source = PresentationSource.FromVisual(MyControl);
        double dpiX = (96 * source.CompositionTarget.TransformToDevice.M11);
        double dpiY = (96 * source.CompositionTarget.TransformToDevice.M22);
        XInScreenCoordinates = ((point.X * 96 / dpiX));
        YInScreenCoordinates = ((point.Y * 96 / dpiY));
