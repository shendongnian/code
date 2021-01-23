	public class ConvertFileImageConverter : IValueConverter
	{
		private static ImageSource DefaultImage = new BitmapImage(...);
		
		public object Convert(object value, 
                              Type targetType, object parameter, CultureInfo culture)
		{
			var filename = (string)value;
			
			if(string.IsNullOrWhiteSpace(filename))
			{
				return null; // or return a default image
			}
			
			var extension = Path.GetExtension(filename).Replace(".", string.Empty);
			
			var imageName = @"\Media\file_extension_" + extension + ".png";
			
			if(!File.Exists(imageName))
			{
				return DefaultImage;
			}
			
			return new BitmapImage(new Uri(imageName, UriKind.Relative));
		}
	}
