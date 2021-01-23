    public class MyAsyncValueConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var val = (string)value;
            var task = Task.Run(async () =>
            {
                await Task.Delay(5000);
                return val + " done!";
            });
            return new TaskCompletionNotifier<string>(task);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
