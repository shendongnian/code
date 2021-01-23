	public class MyDrawing : NSView
	{
		public override void DrawRect (RectangleF dirtyRect)
		{
			var context = NSGraphicsContext.CurrentContext.GraphicsPort;
			context.SetStrokeColor (new CGColor(1.0, 0, 0)); // red
			context.SetLineWidth (1.0F);
			context.StrokeEllipseInRect (new RectangleF(5, 5, 10, 10));
		}
	}
