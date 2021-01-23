	[ValueConversion(typeof(ReadOnlyObservableCollection<ValidationError>), typeof(string))]
	public class ValidationErrorsToStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter,
			CultureInfo culture)
		{
			var errors = value as ReadOnlyObservableCollection<ValidationError>;
			// If there are no errors then return an empty string. 
			// This prevents debug exception messages that result from the usual Xaml of "Path=(Validation.Errors)[0].ErrorContent".
			// Instead we use "Path=(Validation.Errors), Converter={StaticResource ValidationErrorsConverter}".
			if (errors == null)
			{
				return string.Empty;
			}
			var errors2 = errors.Select(e => e.ErrorContent).OfType<string>().ToArray();
			return errors.Any() ? string.Join("\n", errors2) : string.Empty;
		}
		public object ConvertBack(object value, Type targetType, object parameter,
			CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
