    static FixedPage CreateFixedPage(Uri imageSource)
    {
        FixedPage fp = new FixedPage();
        fp.Width = 320;
        fp.Height = 240;
        Grid g = new Grid();
        g.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
        g.VerticalAlignment = System.Windows.VerticalAlignment.Center;
        fp.Children.Add(g);
        Image img = new Image
        {
            UriSource = imageSource,
        };
        g.Children.Add(image);
        return fp;
    }
