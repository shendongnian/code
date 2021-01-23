		// crop using core graphics instead of CIImage
		SizeF newSize = new SizeF(500,500);
		UIGraphics.BeginImageContextWithOptions(size:newSize, opaque:false, scale:0.0f);
		originalImage.Draw (new RectangleF(0,0,originalImage.Size.Width,originalImage.Size.Height));
		UIImage croppedImage = UIGraphics.GetImageFromCurrentImageContext();
		UIGraphics.EndImageContext();
