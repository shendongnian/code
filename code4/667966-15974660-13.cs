    public class FlattenTheModelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var InstanceOfTheModel = value as TheModel;
            return (from b in InstanceOfTheModel.InstanceOfClassA.DictionaryInA.Values
                    from c in b.DictionaryInB.Values
                    select new
                    {
                        PropertyA1 = InstanceOfTheModel .PropertyA1,
                        PropertyA2 = InstanceOfTheModel .PropertyA2,
                        PropertyB1 = b.PropertyB1,
                        PropertyB2 = b.PropertyB2,
                        PropertyC1 = c.PropertyC1,
                        PropertyC2 = c.PropertyC2
                    }).ToList();
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
