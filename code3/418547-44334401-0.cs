    public class YourMapControl : GMapControl
    {
       protected override void OnRender(DrawingContext drawingContext)
       {
          base.OnRender(drawingContext);
          
          Point center(40.730610, -73.935242);
          double radius = 0.1;
          
          drawingContext.DrawEllipse(Brushes.Red, Pens.Black, center, radius, radius);
       }
    }
