    [ValueConversion(typeof(string), typeof(string))]
    public class pathtoname : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter ,CultureInfo culture)
        {
            BindingList<string> ls = value as BindingList<string>;
            List<MyFile> files = new List<MyFile>();
            foreach (string s in ls)
            {
                files.Add(new MyFile() { Filename = Path.GetFileName(s), Fullpath = s });
            }
            return files;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter,CultureInfo culture)
        {
            return null;
        }
    }
