    public static class ImageLoader
    {
    	public static ImageSource GetDefaultImage(DependencyObject obj)
    	{
    		return (ImageSource)obj.GetValue(DefaultImageProperty);
    	}
    	public static void SetDefaultImage(DependencyObject obj, ImageSource value)
    	{
    		obj.SetValue(DefaultImageProperty, value);
    	}
    
    	public static readonly DependencyProperty DefaultImageProperty =
    		DependencyProperty.RegisterAttached(
    		"DefaultImage",
    		typeof(ImageSource),
    		typeof(ImageLoader),
    		new UIPropertyMetadata(null));
    
    	public static ImageSource GetHoverImage(DependencyObject obj)
    	{
    		return (ImageSource)obj.GetValue(HoverImageProperty);
    	}
    	public static void SetHoverImage(DependencyObject obj, ImageSource value)
    	{
    		obj.SetValue(HoverImageProperty, value);
    	}
    
    	public static readonly DependencyProperty HoverImageProperty =
    		DependencyProperty.RegisterAttached(
    		"HoverImage",
    		typeof(ImageSource),
    		typeof(ImageLoader),
    		new UIPropertyMetadata(null));
    
    	public static ImageSource GetDisabledImage(DependencyObject obj)
    	{
    		return (ImageSource)obj.GetValue(DisabledImageProperty);
    	}
    	public static void SetDisabledImage(DependencyObject obj, ImageSource value)
    	{
    		obj.SetValue(DisabledImageProperty, value);
    	}
    
    	public static readonly DependencyProperty DisabledImageProperty =
    		DependencyProperty.RegisterAttached(
    		"DisabledImage",
    		typeof(ImageSource),
    		typeof(ImageLoader),
    		new UIPropertyMetadata(null));
    }
