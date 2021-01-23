    public class TextToTipConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            TipViewModel tipViewModel = value as TipViewModel;
            SearchStrategy strategy = tipViewModel.SearchStrategy;
            string searchString = tipViewModel.SearchString;
            return Strategy.parseInput<string>(searchString , (first, inp) => strategy .tipMap.ContainsKey(first) && inp.Length == 1 ? first + strategy .tipMap[first] : "", AppResources.GeneralSearchTip);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
