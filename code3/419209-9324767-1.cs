    public class FileNameCheckConverter: IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var filename = (string)values[0];
            var newfilename = (string)values[1];
            return filename==newfilename;
        }
   
        ...
    }
