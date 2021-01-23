    public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (values[0] is ObservableCollection<myData> && values[1] is int)
        {
            var collection = (ObservableCollection<myData>)values[0];
            var time = (int)values[1];
            return collection.Any() && collection.Max(x => x.mdTime).Equals(time)
                ? new SolidColorBrush(Colors.Red)
                : new SolidColorBrush(Colors.Black);
        }
        return new SolidColorBrush(Colors.Black);
    }
