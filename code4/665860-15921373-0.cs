    private Polyline polyline;
    private Polyline segment = new Polyline { StrokeThickness = 2 };
    private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (polyline == null)
        {
            var canvas = (Canvas)sender;
            var point = e.GetPosition(canvas);
            // create new polyline
            polyline = new Polyline { Stroke = Brushes.Black, StrokeThickness = 2 };
            polyline.Points.Add(point);
            canvas.Children.Add(polyline);
            // initialize current polyline segment
            segment.Stroke = Brushes.Red;
            segment.Points.Add(point);
            segment.Points.Add(point);
            canvas.Children.Add(segment);
        }
    }
    private void Canvas_MouseMove(object sender, MouseEventArgs e)
    {
        if (polyline != null)
        {
            // update current polyline segment
            var canvas = (Canvas)sender;
            segment.Points[1] = e.GetPosition(canvas);
            var distance = (segment.Points[0] - segment.Points[1]).Length;
            segment.Stroke = distance >= 20 ? Brushes.Green : Brushes.Red;
        }
    }
    private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        if (polyline != null)
        {
            var canvas = (Canvas)sender;
            segment.Points[1] = e.GetPosition(canvas);
            var distance = (segment.Points[0] - segment.Points[1]).Length;
            if (distance >= 20)
            {
                polyline.Points.Add(segment.Points[1]);
                segment.Points[0] = segment.Points[1];
            }
            else
            {
                if (polyline.Points.Count < 2)
                {
                    canvas.Children.Remove(polyline);
                }
                polyline = null;
                segment.Points.Clear();
                canvas.Children.Remove(segment);
            }
        }
    }
