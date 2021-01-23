    foreach (IConvertible e in Enum.GetValues(typeof(TEnum)))
    {
        list.Add(new KeyValuePair<string, string>(
            e.ToString(),
            e.ToType(
                Enum.GetUnderlyingType(typeof(TEnum)),
                CultureInfo.CurrentCulture).ToString()));
    }
