    class CustomConverter : IMultiValueConverter 
    {
        public object Convert (object[] Values, Type Target_Type, object Parameter, CultureInfo culture) 
        {
            var findCommandParameters = new FindCommandParameters();
            findCommandParameters.Property1 = (string)values[0];
            findCommandParameters.Property1 = (string)values[1];
            return findCommandParameters;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter,   System.Globalization.CultureInfo culture)
        {
           throw new NotImplementedException();
        }
    }
