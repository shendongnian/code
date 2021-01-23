    private void Thumb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        var thumb = e.Source as UIElement;
        var transform = thumb.RenderTransform as RotateTransform;
        transform.Angle += 90;
    }
