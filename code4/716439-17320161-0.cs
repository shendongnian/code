    class PriceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            double price = Convert.ToDouble(value);
            if(price > 5.0)
            {
                // return the price formatted how you want
            }
            else
            {
                // return the price formatted differently
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
