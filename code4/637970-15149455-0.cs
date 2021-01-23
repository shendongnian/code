    // Custom class implements the IValueConverter interface.
    public class StyleConverter : IValueConverter
    {
        #region IValueConverter Members
        // Define the Convert method to change a title ending with > 3 
        // to a red background, otherwise, green.
        public object Convert(object value, Type targetType,
            object parameter, string language)
        {
            // The value parameter is the data from the source object.
            string title = (string)value;
            int lastNum = (int.Parse(title.Substring(title.Length - 1)));
            if (lastNum > 3)
            {
                return "Red";
            }
            else
            {
                return "Green";
            }
        }
        // ConvertBack is not implemented for a OneWay binding.
        public object ConvertBack(object value, Type targetType,
            object parameter, string language)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
