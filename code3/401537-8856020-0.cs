    foreach (object obj in LogicalTreeHelper.GetChildren(this))
    {
        if (obj is Image)
        {
        Image img = (Image)obj;
        img.Visibility = Visibility.Hidden;
        }
    }
