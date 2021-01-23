    class TimeSpanRoundUpConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is TimeSpan && parameter is TimeSpan))
            {
                return Binding.DoNothing;
            }
            return RoundUpTimeSpan((TimeSpan)value, (TimeSpan)parameter);
        }
        private static TimeSpan RoundUpTimeSpan(TimeSpan value, TimeSpan roundTo)
        {
            if (value < TimeSpan.Zero) return RoundUpTimeSpan(-value, roundTo);
            double quantization = roundTo.TotalMilliseconds, input = value.TotalMilliseconds;
            double normalized = input / quantization;
            int wholeMultiple = (int)normalized;
            double fraction = normalized - wholeMultiple;
            return TimeSpan.FromMilliseconds((fraction == 0 ? wholeMultiple : wholeMultiple + 1) * quantization);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
