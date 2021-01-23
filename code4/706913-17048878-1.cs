    ConnectBoxes(Root, rect1, rect2);
    ....
    public void ConnectBoxes(Canvas container, Rectangle boxeSrc, Rectangle boxeDest)
    {
        var transform1 = boxeSrc.TransformToVisual(container);
        var transform2 = boxeDest.TransformToVisual(container);
    
        var lineGeometry = new LineGeometry()
        {
            StartPoint = transform1.Transform(
                new Point(boxeSrc.ActualWidth / 2, boxeSrc.ActualHeight / 2.0)
            ),
            EndPoint = transform2.Transform(
                new Point(boxeDest.ActualWidth / 2.0, boxeDest.ActualHeight / 2.0)
            )
        };
        container.Children.Add(new Path()
        {
            Data = lineGeometry,
            Fill = new SolidColorBrush(Colors.Brown),
            Stroke = new SolidColorBrush(Colors.Brown),
                    
        });
    }
