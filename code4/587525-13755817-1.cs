	private UIView CreateBlurView(UIView view)
	{
		UIGraphics.BeginImageContext(view.Bounds.Size);
		view.Layer.RenderInContext(UIGraphics.GetCurrentContext());
		UIImage viewImage = UIGraphics.GetImageFromCurrentImageContext();
		UIGraphics.EndImageContext ();
		// Blur Image
		CIImage imageToBlur = CIImage.FromCGImage(viewImage.CGImage);
		CIFilter gaussianBlurFilter = CIFilter.FromName("CIGaussianBlur");
		gaussianBlurFilter.SetValueForKey(imageToBlur,new NSString("inputImage"));
		gaussianBlurFilter.SetValueForKey(new NSNumber(10.0f),new NSString("inputRadius"));
		CIImage resultImage = (CIImage) gaussianBlurFilter.ValueForKey(new NSString("outputImage"));
			
		UIImage finalImage = new UIImage(resultImage, 1.0f, UIImageOrientation.Up);
		UIImageView  imageView = new UIImageView(view.Bounds);
		imageView.Image = finalImage;
	}
