    public class GradientColorConverter:IValueConverter 
    {
        #region Implementation of IValueConverter
        /// <summary>
        /// Converts a value. 
        /// </summary>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <param name="value">The value produced by the binding source.</param><param name="targetType">The type of the binding target property.</param><param name="parameter">The converter parameter to use.</param><param name="culture">The culture to use in the converter.</param>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is Color==false)
                return Binding.DoNothing;
            var color = (Color) value;
            var stops = new GradientStopCollection();
            stops.Add(new GradientStop(color, 0));
            stops.Add(new GradientStop(Colors.Gray, 1));
            var brush = new LinearGradientBrush(stops);
            brush.StartPoint = new Point(0, 0);
            brush.EndPoint = new Point(0, 1);
            return brush;
        }
        /// <summary>
        /// Converts a value. 
        /// </summary>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <param name="value">The value that is produced by the binding target.</param><param name="targetType">The type to convert to.</param><param name="parameter">The converter parameter to use.</param><param name="culture">The culture to use in the converter.</param>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
