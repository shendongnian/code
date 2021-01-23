    switch (ElementInfoCollection[pos].ArrowDirection)
    {
        LeftArrow.Visibility = Visibility.Collapsed;
        RightArrow.Visibility = Visibility.Collapsed;
        TopArrow.Visibility = Visibility.Collapsed;
        BottomArrow.Visibility = Visibility.Collapsed;
    
        case ArrowDirection.Left: LeftArrow.Visibility = Visibility.Visible; break;
        case ArrowDirection.Right: RightArrow.Visibility = Visibility.Visible; break;
        case ArrowDirection.Top: TopArrow.Visibility = Visibility.Visible; break;
        case ArrowDirection.Bottom: BottomArrow.Visibility = Visibility.Visible; break;
        default: break;
    }
