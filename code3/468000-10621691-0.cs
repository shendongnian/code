    var input = value as string;
    if (input == null || string.IsNullOrWhiteSpace(input))
    {
        return Visibility.Collapsed;
    }
    else
    {
        return Visibility.Visible;
    }
