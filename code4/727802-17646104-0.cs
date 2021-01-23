    public static Ellipse SomeCircle( Canvas dest)
    {
        Ellipse e = new Ellipse();
        double size = 10;
        e.Height = size;
        e.Width = size;
        e.Fill = new SolidColorBrush(Colors.Orange);
        e.Fill.Opacity = 0.8;
        e.Stroke = new SolidColorBrush(Colors.Black);
        dest.Children.Add(e);
        return e;
    }
