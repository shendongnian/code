    private void AddButtonClick(object sender, RoutedEventArgs e)
    {
        var dialog = new Microsoft.Win32.OpenFileDialog();
        dialog.Filter = "Image Files (*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
        if ((bool)dialog.ShowDialog())
        {
            var bitmap = new BitmapImage(new Uri(dialog.FileName));
            var image = new Image { Source = bitmap };
            Canvas.SetLeft(image, 0);
            Canvas.SetTop(image, 0);
            canvas.Children.Add(image);
        }
    }
    private Image draggedImage;
    private Point mousePosition;
    private void CanvasMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var position = e.GetPosition(canvas);
        var image = canvas.InputHitTest(position) as Image;
        if (image != null)
        {
            canvas.CaptureMouse();
            draggedImage = image;
            mousePosition = position;
        }
    }
    private void CanvasMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        if (draggedImage != null)
        {
            canvas.ReleaseMouseCapture();
            draggedImage = null;
        }
    }
    private void CanvasMouseMove(object sender, MouseEventArgs e)
    {
        if (draggedImage != null)
        {
            var position = e.GetPosition(canvas);
            var offset = position - mousePosition;
            mousePosition = position;
            Canvas.SetLeft(draggedImage, Canvas.GetLeft(draggedImage) + offset.X);
            Canvas.SetTop(draggedImage, Canvas.GetTop(draggedImage) + offset.Y);
        }
    }
