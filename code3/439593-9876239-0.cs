    UniformGrid grid = new UniformGrid();
    grid.Columns = 10;
    grid.Rows = 10;
    grid.Width = columnWidth * 10;
    grid.Height = rowHeight * 10;
    for (int x = 0; x < 10; x++)
    {
        for (int y = 0; y < 10; y++)
        {
            if (fields[x, y] is SomeImage)
            {
                Image img = new Image();
                img.Source = someImageSource;
                grid.Children.Add(img);
            }
            else
            {
                Rectangle rect = new Rectangle();
                rect.Fill = someColor;
                grid.Children.Add(rect);
            }
        }
    }
    Canvas.SetLeft(grid, (canvas.Width - grid.Width) / 2);
    Canvas.SetTop(grid, (canvas.Height - grid.Height) / 2);
    canvas.Children.Add(grid);
