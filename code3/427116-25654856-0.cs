    var topTB = new TextBox();
    var middleTB = new TextBox();
    var bottomTB = new TextBox();
    var g = MakeSideBySideFrames(this.Root, topTB, middleTB, bottomTB);
    g.Height = 300.0;
    public Grid MakeTopBottomFrames(Panel parent, params UIElement[] items)
    {
        return MakeFrames(parent, 
            newPosition: (g, len)    => { g.   RowDefinitions.Add(new RowDefinition    { Height = len }); },
            setPosition: (item, inx) => { Grid.SetRow(item, inx); },
            items: items);
    }
    public Grid MakeSideBySideFrames(Panel parent, params UIElement[] items)
    {
        return MakeFrames(parent, 
            newPosition: (g, len)    => { g.ColumnDefinitions.Add(new ColumnDefinition { Width = len }); },
            setPosition: (item, inx) => { Grid.SetColumn(item, inx); },
            items: items);
    }
    Grid MakeFrames(Panel parent, 
            Action<Grid, GridLength> newPosition,
            Action<UIElement, int> setPosition,
            params UIElement[] items
        )
    {
        var g = new Grid();
        parent.Children.Add(g);
        for (var inx = 0; inx < items.Length; inx++)
        {
            if (inx > 0)
            {
                newPosition(g, new GridLength(5));
                var gs = new GridSplitter();
                g.Children.Add(gs);
                setPosition(gs, (inx * 2) - 1);
                gs.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
                gs.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
                gs.Background = new SolidColorBrush(Colors.Black);
                gs.ShowsPreview = true;
            }
            newPosition(g, new GridLength(1, GridUnitType.Star));
            g.Children.Add(items[inx]);
            setPosition(items[inx], inx * 2);
        }
        return g;
    }
