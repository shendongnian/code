    public static string DotFormatToRowKey(this string dotFormatRowKey) 
    {
    
        if (! Regex.IsMatch(dotFormatRowKey, @"\d+\.\d+"))
           throw new ArgumentException("Expected ##.##, was " + dotFormatRowKey);
    
        var splits = dotFormatRowKey.Split('.')
                     .Select(x => String.Format("{0:d2}", Int32.Parse(x)))
                     .ToList();
        return String.Join(String.Empty, splits.ToArray());
    }
