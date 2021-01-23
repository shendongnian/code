    class igStringFormatConverter : IValueConverter
    {
        #region IValueConverter Members
    
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime dt = (DateTime)value;
            string fmtDt = String.Format("{0:" + parameter.ToString() + "}", dt);          
            return fmtDt;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    
        #endregion
    }
