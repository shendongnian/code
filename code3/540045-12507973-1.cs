    public class NameConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if((values[1] as int) == 1)
            {
               return (values[0].ToString()) + "\t" + values[1].ToString() + "Member";
            }
            return (values[0].ToString()) + "\t" + values[1].ToString() + "Members";            
        }
        /* ... */   
    }
