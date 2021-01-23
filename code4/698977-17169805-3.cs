    using System.Windows;
    using System.Windows.Media;
    namespace WpfApplication10
    {
    	public static class ImageButton
    	{
    		public static readonly DependencyProperty
    		    		ImageProperty = DependencyProperty.RegisterAttached(
    							"Image",
    							typeof(ImageSource),
    							typeof(ImageButton),
    							new FrameworkPropertyMetadata((ImageSource)null));
		
    		public static ImageSource GetImage(DependencyObject obj)
    		{
    			return (ImageSource)obj.GetValue(ImageProperty);
    		}
    		public static void SetImage(DependencyObject obj, ImageSource value)
    		{
    			obj.SetValue(ImageProperty, value);
    		}
    	}
    }
