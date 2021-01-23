	private void DrawOnBitmap()
	{
		using (var bitmap = new Bitmap(this.Width, this.Height))
		{
			using (var bitmapGraphics = Graphics.FromImage(bitmap))
			{
				// Draw on the bitmap
				var pen = new Pen(Color.Red);
				var rect = new Rectangle(20, 20, 100, 100);
				bitmapGraphics.DrawRectangle(pen, rect);
				// Display the bitmap on the form
				using (var formGraphics = this.CreateGraphics())
				{
					formGraphics.DrawImage(bitmap, new Point(0, 0));
				}
				// Save the bitmap
				bitmap.Save("image.bmp");
			}
		}
	}	
