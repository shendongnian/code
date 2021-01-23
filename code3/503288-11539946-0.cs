    Graphics gg = this.CreateGraphics();
    Pen pen = new Pen(Color.Blue, 2);
    foreach (Line line in Lines) {
        gg.DrawLine(pen, line.StartPoint.X, line.StartPoint.Y,
                         line.EndPoint.X, line.EndPoint.Y);
    }
