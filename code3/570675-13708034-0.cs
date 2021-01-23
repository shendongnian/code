    public class MyVisualHost : FrameworkElement
    {
    private readonly VisualCollection children;
    public MyVisualHost(int width)
    {
        children = new VisualCollection(this);
        var visual = new DrawingVisual();
        children.Add(visual);
        var currentTime = new TimeSpan(0, 0, 0, 0, 0);
        const int everyXLine100 = 10;
        double currentX = 0;
        var currentLine = 0;
        double distanceBetweenLines = 5;
        TimeSpan timeStep = new TimeSpan(0, 0, 0, 0, 10);
        int majorEveryXLine = 100;
        var grayBrush = new SolidColorBrush(Color.FromRgb(192, 192, 192));
        grayBrush.Freeze();
        var grayPen = new Pen(grayBrush, 2);
        var whitePen = new Pen(Brushes.White, 2);
        grayPen.Freeze();
        whitePen.Freeze();
        using (var dc = visual.RenderOpen())
        {
            while (currentX < width)
            {
                if (((currentLine % majorEveryXLine) == 0) && currentLine != 0)
                {
                    dc.DrawLine(whitePen, new Point(currentX, 30), new Point(currentX, 15));
                    var text = new FormattedText(
                        currentTime.ToString(@"hh\:mm\:ss\.fff"),
                        CultureInfo.CurrentCulture,
                        FlowDirection.LeftToRight,
                        new Typeface("Tahoma"),
                        8,
                        grayBrush);
                    dc.DrawText(text, new Point((currentX - 22), 0));
                }
                else if ((((currentLine % everyXLine100) == 0) && currentLine != 0)
                            && (currentLine % majorEveryXLine) != 0)
                {
                    dc.DrawLine(grayPen, new Point(currentX, 30), new Point(currentX, 20));
                    var text = new FormattedText(
                        string.Format(".{0}", currentTime.Milliseconds),
                        CultureInfo.CurrentCulture,
                        FlowDirection.LeftToRight,
                        new Typeface("Tahoma"),
                        8,
                        grayBrush);
                    dc.DrawText(text, new Point((currentX - 8), 8));
                }
                else
                {
                    dc.DrawLine(grayPen, new Point(currentX, 30), new Point(currentX, 25));
                }
                currentX += distanceBetweenLines;
                currentLine++;
                currentTime += timeStep;
            }
        }
    }
    // Provide a required override for the VisualChildrenCount property.
    protected override int VisualChildrenCount { get { return children.Count; } }
    // Provide a required override for the GetVisualChild method.
    protected override Visual GetVisualChild(int index)
    {
        if (index < 0 || index >= children.Count)
        {
            throw new ArgumentOutOfRangeException();
        }
        return children[index];
    }
    }
