    public Point GetDpiSafeLocation(Point location)
    {
        PresentationSource source = PresentationSource.FromVisual(Application.Current.MainWindow);
        if (source != null)
        {
            double dpiX = 96.0 * source.CompositionTarget.TransformToDevice.M11;
            double dpiY = 96.0 * source.CompositionTarget.TransformToDevice.M22;
            return new Point(location.X * 96.0 / dpiX, location.Y * 96.0 / dpiY);
        }
        return location;
    }
