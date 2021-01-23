    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;
	public static class Extensions
	{
		public static Image ImageFromRawBgraArray(
			this byte[] arr, int width, int height)
		{
			var output = new Bitmap(width, height);
			var rect = new Rectangle(0, 0, width, height);
			var bmpData = output.LockBits(rect, 
				ImageLockMode.ReadWrite, output.PixelFormat);
			var ptr = bmpData.Scan0;
			Marshal.Copy(arr, 0, ptr, arr.Length);
			output.UnlockBits(bmpData);
			return output;
		}
	}
