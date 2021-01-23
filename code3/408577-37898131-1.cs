	/// <summary>
	/// Wrapper class for the gdi32.dll.
	/// </summary>
	public class Gdi32
	{
		public enum DrawingMode
		{
			R2_NOTXORPEN = 10
		}
		[DllImport("gdi32.dll")]
		public static extern bool Rectangle(IntPtr hDC, int left, int top, int right, int bottom);
		[DllImport("gdi32.dll")]
		public static extern int SetROP2(IntPtr hDC, int fnDrawMode);
		[DllImport("gdi32.dll")]
		public static extern bool MoveToEx(IntPtr hDC, int x, int y, ref Point p);
		[DllImport("gdi32.dll")]
		public static extern bool LineTo(IntPtr hdc, int x, int y);
		[DllImport("gdi32.dll")]
		public static extern IntPtr CreatePen(int fnPenStyle, int nWidth, int crColor);
		[DllImport("gdi32.dll")]
		public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObj);
		[DllImport("gdi32.dll")]
		public static extern bool DeleteObject(IntPtr hObj);
		
	}
	/// <summary>
	/// Provides utilities directly accessing the gdi32.dll 
	/// </summary>
	public class GDI
	{
		static private Point nullPoint = new Point(0,0);
		// Convert the Argb from .NET to a gdi32 RGB
		static private int ArgbToRGB(int rgb)
		{
			return ((rgb >> 16 & 0x0000FF)| (rgb & 0x00FF00) | (rgb << 16 & 0xFF0000));
		}
		static public void DrawXORRectangle(Graphics graphics, Pen pen, Rectangle rectangle)
		{
			IntPtr hDC = graphics.GetHdc();
			IntPtr hPen = Gdi32.CreatePen(0, (int)pen.Width, ArgbToRGB(pen.Color.ToArgb()));
			Gdi32.SelectObject(hDC, hPen);
			Gdi32.SetROP2(hDC, (int)Gdi32.DrawingMode.R2_NOTXORPEN);
			Gdi32.Rectangle(hDC, rectangle.Left, rectangle.Top, rectangle.Right,rectangle.Bottom);
			Gdi32.DeleteObject(hPen);
			graphics.ReleaseHdc(hDC);
		}
		static public void DrawXORLine(Graphics graphics, Pen pen, int x1, int y1, int x2, int y2)
		{
			IntPtr hDC = graphics.GetHdc();
			IntPtr hPen = Gdi32.CreatePen(0, (int)pen.Width, ArgbToRGB(pen.Color.ToArgb()));
			Gdi32.SelectObject(hDC, hPen);
			Gdi32.SetROP2(hDC, (int)Gdi32.DrawingMode.R2_NOTXORPEN);
			Gdi32.MoveToEx(hDC, x1, y1, ref nullPoint);
			Gdi32.LineTo(hDC, x2, y2);
			Gdi32.DeleteObject(hPen);
			graphics.ReleaseHdc(hDC);
		}
	}
