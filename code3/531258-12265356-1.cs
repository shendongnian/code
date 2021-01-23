    public class MyRect : Panel
    {
        protected override void OnRender(DrawingContext drawingContext)
        {
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = Colors.LimeGreen;
            Pen myPen = new Pen(Brushes.Blue, 10);
            Rect myRect = new Rect(0, 0, 500, 500);
            drawingContext.DrawRectangle(mySolidColorBrush, myPen, myRect);
        }
    }
