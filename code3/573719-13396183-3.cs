    private void GridSizeChanged(object sender, SizeChangedEventArgs e)
    {
        double newHeight = e.NewSize.Height;
        int lb1ItemCount = lb1.Items.Count;
        int lb2ItemCount = lb2.Items.Count;
        row1.Height = new GridLength(newHeight * lb1ItemCount / (lb1ItemCount + lb2ItemCount));
        row2.Height = new GridLength(newHeight * lb2ItemCount / (lb1ItemCount + lb2ItemCount));
    }
