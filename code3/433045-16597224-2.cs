    public class CycleStrings : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            string s = (string)value;
            List<string> allStrings = new List<string>() {
                "One",
                "Two",
                "Three",
                "Four",
            }
            // Find the index of the next string along
            int i = allStrings.IndexOf(s);
            i = (i + 1) % allStrings.Count;
            return allStrings[i];
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            throw new NotImplementedException();
        }
    }
