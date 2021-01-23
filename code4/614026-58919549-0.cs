using System;
using System.Text;
using Windows.UI.Xaml.Data;
namespace MyApp.Converters
{
    public class ByteSizeConverter : IValueConverter
    {
        static readonly string[] sSizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        // The number of decimal places the formatter should include in the scaled output - default 1dp
        public int DecimalPlaces { get; set; } = 1;
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Int64 intVal = System.Convert.ToInt64(value);
            return SizeSuffix(intVal);
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            // TODO: Parse string into number and suffix
            //       Scale number by suffix multiplier to get bytes
            throw new NotImplementedException();
        }
        string SizeSuffix(Int64 value)
        {
            if (this.DecimalPlaces < 0) { throw new ArgumentOutOfRangeException(String.Format("DecimalPlaces = {0}", this.DecimalPlaces)); }
            if (value < 0) { return "-" + SizeSuffix(-value); }
            if (value == 0) { return string.Format("{0:n" + this.DecimalPlaces + "} bytes", 0); }
            // magnitude is 0 for bytes, 1 for KB, 2, for MB, etc.
            int magnitude = (int)Math.Log(value, 1024);
            // clip magnitude - only 8 values currently supported, this prevents out-of-bounds exception
            magnitude = Math.Min(magnitude, 8);
            
            // 1L << (magnitude * 10) == 2 ^ (10 * magnitude) [i.e. the number of bytes in the unit corresponding to magnitude]
            decimal adjustedSize = (decimal)value / (1L << (magnitude * 10));
            // make adjustment when the value is large enough that it would round up to 1000 or more
            if (Math.Round(adjustedSize, this.DecimalPlaces) >= 1000)
            {
                magnitude += 1;
                adjustedSize /= 1024;
            }
            return String.Format("{0:n" + this.DecimalPlaces + "} {1}", adjustedSize, sSizeSuffixes[magnitude]);
        }
    }
}
To use it, add a local resource to your UserControl or Page XAML:
<UserControl.Resources>
    <converters:ByteSizeConverter x:Key="ByteFormat" DecimalPlaces="3" />
</UserControl.Resources>
Reference it in a data binding template or data binding instance:
<TextBlock HorizontalAlignment="Left" VerticalAlignment="Center"
    Text="{x:Bind MyItem.FileSize_bytes, Mode=OneWay, Converter={StaticResource ByteFormat}}" />
And hey presto. The magic happens.
