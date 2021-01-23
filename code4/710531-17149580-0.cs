    public class MyClass{
	private static readonly objLock = new Object();
	private void myEnqThread()
			{
				Bitmap temp = null;
				temp = getScreen();
				if(temp!=null)
					queueScreen.Enqueue(temp);
			}
			private Bitmap getScreen(){
				System.Drawing.Bitmap bitmapDesktop;
				System.Drawing.Graphics graphics;
				System.IntPtr hWndForeground;// = System.IntPtr.Zero;
				RECT rect = new RECT();
				bitmapDesktop = null;
				graphics = null;
				hWndForeground = System.IntPtr.Zero;
				lock(objLock){
					bitmapDesktop = new Bitmap
					(
						    System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width,
						System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height,
						System.Drawing.Imaging.PixelFormat.Format24bppRgb
					);
					graphics = System.Drawing.Graphics.FromImage(bitmapDesktop);
					hWndForeground = GetForegroundWindow();
					GetWindowRect(hWndForeground, out rect);
					graphics.DrawRectangle(Pens.Red, rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
					return bitmapDesktop;
				}
			}	
