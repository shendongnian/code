    public class ThumbToFullPathConverter : IValueConverter
    {
        public object Convert(object value, Type targettype, object parameter, string Path)
        {
            return ("ms-appdata:///local/" + value).ToString();
        }
        public object ConvertBack(object value, Type targettype, object parameter, string Path)
        {
            throw new NotImplementedException();
        }
    }
