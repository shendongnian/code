    private void Draw()
    {
        Line[] lines = new Line[100];
        int scale = 3;
        canvas1.Children.Clear();
        int yStart = 290;
        for (int i = 0; i < lines.Length; i++)
        {
            //data[i] = i;
            lines[i] = new Line()
            {
                X1 = i * scale,
                Y1 = yStart,
                X2 = i * scale,
                Y2 = 300 - (i * scale),
                StrokeThickness = 1,
                Stroke = new SolidColorBrush(Colors.Black)
            };
            canvas1.Children.Add(lines[i]);
        }
    }
