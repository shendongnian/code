    public object Convert(object value, Type targetType, object parameter, string language)
    {
        var col = value as ICollection;
        if (col != null)
            return col.Count > 0 ? Visibility.Visible : Visibility.Collapsed;
        var enu = (IEnumerable)value;
        using (var enumerator = enu.GetEnumerator())
            return enumerator.MoveNext() ? Visibility.Visible : Visibility.Collapsed;
    }
