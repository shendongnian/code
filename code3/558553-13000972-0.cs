    Point positionWithinImage;
    private void ImagePointerPressed(object sender, PointerRoutedEventArgs e)
    {
        Debug.WriteLine("Pressed");
        holding = true;
        positionWithinImage = e.GetCurrentPoint(sender as Image).Position;
    }
    private void ImagePointerReleased(object sender, PointerRoutedEventArgs e)
    {
        Debug.WriteLine("Released");
        holding = false;
    }
    bool holding = false;
    private void GridPointerMoved(object sender, PointerRoutedEventArgs e)
    {
        if (holding)
        {
            var pos = e.GetCurrentPoint(image1.Parent as Grid).Position;
            image1.Margin = new Thickness(pos.X - this.positionWithinImage.X, pos.Y - this.positionWithinImage.Y, 0, 0);
        }
    }
