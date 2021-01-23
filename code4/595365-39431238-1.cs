    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        RenderTargetBitmap bitMap = new RenderTargetBitmap();
        await bitMap.RenderAsync(grid);
        Image image = new Image();// This is a Image
        image.Source = bitMap;
        image.Height = 150;
        image.Width = 100;
           
        grid.Children.Add(image);
    }
