			// Create layers of matter on the battlefield.  Example:  Grass, dirt, water
			Water = new UIImageView(UIScreen.MainScreen.Bounds);
			Water_OriginalImage = UIImage.FromFile("WaterTexture.png");
			Water.Image = Water_OriginalImage;
			this.View.AddSubview(Water);
			
			Dirt = new UIImageView(UIScreen.MainScreen.Bounds);
			Dirt_ModifiableImage = UIImage.FromFile("DirtBackground.png");
			Dirt.Image = null;
			this.View.AddSubview(Dirt);
			
			
			
			CGImage image = Dirt_ModifiableImage.CGImage;
			int width = image.Width;
			int height = image.Height;
			CGColorSpace colorSpace = image.ColorSpace;
			int bytesPerRow = image.BytesPerRow;
			// int bytesPerPixel = 4;
			int bytesPerPixel = bytesPerRow / width;
			int bitmapByteCount = bytesPerRow * height;
			int bitsPerComponent = image.BitsPerComponent;
			CGImageAlphaInfo alphaInfo = image.AlphaInfo;
			
			// Allocate memory because the BitmapData is unmanaged
			IntPtr BitmapData = Marshal.AllocHGlobal(bitmapByteCount);
            CGBitmapContext context = new CGBitmapContext(BitmapData, width, height, bitsPerComponent, bytesPerRow, colorSpace, alphaInfo);
			context.SetBlendMode(CGBlendMode.Copy);
			context.DrawImage(new RectangleF(0, 0, width, height), image);
			int tempX = 0;
			while ( tempX < Dirt_ModifiableImage.Size.Width )
			{
				int tempY = 0;
				while ( tempY < Dirt_ModifiableImage.Size.Height )
				{
					int byteIndex = (bytesPerRow * tempY) + tempX * bytesPerPixel;
				
					ZeroByte(byteIndex+3, BitmapData);
					byte red = GetByte(byteIndex, BitmapData);
					byte green = GetByte(byteIndex+1, BitmapData);
					byte blue = GetByte(byteIndex+2, BitmapData);
					byte alpha = GetByte(byteIndex+3, BitmapData);
					
					//Console.WriteLine("red = " + red + " green = " + green + " blue = " + blue + " alpha = " + alpha);
					tempY++;
				}
				tempX++;
			}
				NSData newImageData = NSData.FromBytes(BitmapData, (uint)(bitmapByteCount));
				Dirt.Image = UIImage.LoadFromData(newImageData);
