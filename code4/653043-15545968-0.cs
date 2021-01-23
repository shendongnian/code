    for(int i=0; i<...;i++)
    {
        img = new System.Windows.Controls.Image();  // This makes the difference.
        img.Source = bmp;
        dynamicStackPanel.Children.Add(img);
    }
