    void cnvDrawingArea_MouseDown(object sender, MouseButtonEventArgs e)
    {
        Point ClickPoint = e.GetPosition(cnvDrawingArea);
        Rectangle Rectangle = new Rectangle();
        System.Windows.Controls.Canvas.SetTop(Rectangle, ClickPoint.Y)
        System.Windows.Controls.Canvas.SetLeft(Rectangle, ClickPoint.X)
        cnvDrawingArea.Children.Add(Rectangle);
    }
