    public class KepPathKonverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			BitmapImage o;
			try
			{
				o = new BitmapImage(new Uri($"{Main.baseDir}\\{value}"));
			}
			catch (Exception ex)
			{
				o = new BitmapImage();
			}
			return o;
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
	}
