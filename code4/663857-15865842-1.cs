        [ValueConversion(typeof(List<string>), typeof(List<string>))]
        public class MonthConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
            //get the list of months from the object sent in    
            List<string> months = (List<string>)value;
            //manipulate the data index starts at 0 so add 1 and set to 2 decimal places
            if (months != null && months.Count > 0)
            {
                for (int x = 0; x < months.Count; x++)
                {
                    months[x] = (x + 1).ToString("D2") + " - " + months[x];
                }
            }
            return months;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
