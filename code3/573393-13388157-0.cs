    void MyCanvas_MouseDown(object sender, MouseButtonEventArgs e)
    {
        Point ClickPoint = e.GetPosition(MyCanvas);
        Rectangle Rectangle = new Rectangle();
        System.Windows.Controls.Canvas.SetTop(Rectangle, ClickPoint.Y)
        System.Windows.Controls.Canvas.SetLeft(Rectangle, ClickPoint.X)
        MyCanvas.Children.Add(Rectangle);
    }
