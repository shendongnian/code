    	public class ScreenCapture
	{
		[System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
		private static extern bool BitBlt(
			IntPtr hdcDest, // handle to destination DC
			int nXDest, // x-coord of destination upper-left corner
			int nYDest, // y-coord of destination upper-left corner
			int nWidth, // width of destination rectangle
			int nHeight, // height of destination rectangle
			IntPtr hdcSrc, // handle to source DC
			int nXSrc, // x-coordinate of source upper-left corner
			int nYSrc, // y-coordinate of source upper-left corner
			System.Int32 dwRop // raster operation code
			);
		/// <summary>
		/// Returns an image of the control
		/// </summary>
		/// <param name="control">The control object whose image is wanted</param>
		/// <returns>Image of the control</returns>
		/// <remarks>This is based on code from 
		/// http://www.dotnet247.com/247reference/a.aspx?u=http://www.c-sharpcorner.com/Code/2002/April/ScreenCaptureUtility.asp 
        /// with changes made to prevent 0D0B0C transparency issues</remarks>
		public static Image GetControlImage(Control control)
		{
			Graphics g1 = control.CreateGraphics();
			
			// Create a bitmap the same size as the control
            Image MyImage = new Bitmap(control.ClientRectangle.Width, control.ClientRectangle.Height, PixelFormat.Format32bppRgb);
            (MyImage as Bitmap).SetResolution(g1.DpiX, g1.DpiY);
			Graphics g2 = Graphics.FromImage(MyImage);
			IntPtr dc1 = g1.GetHdc();
			IntPtr dc2 = g2.GetHdc();
			
			// BitBlt from one DC to the other
			BitBlt(dc2, 0, 0, control.ClientRectangle.Width, control.ClientRectangle.Height, dc1, 0, 0, 13369376);
			
			// Release Device Contexts
			g1.ReleaseHdc(dc1);
			g2.ReleaseHdc(dc2);
			
			// This statement runs the garbage collector manually
			// (If not present, uses up large amounts of memory...)
			GC.Collect();
			
			return MyImage;
		}
	}
