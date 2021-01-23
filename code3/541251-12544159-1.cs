    public static string DotFormatToRowKey(this string dotFormatRowKey) 
    {
        if (dotFormatRowKey == null)
            throw new ArgumentNullException("dotFormatRowKey");    
        if (! Regex.IsMatch(dotFormatRowKey, @"\d+\.\d+"))
           throw new ArgumentException("Expected ##.##, was " + dotFormatRowKey);
    
        var splits = dotFormatRowKey.Split('.')
                     .Select(x => String.Format("{0:d2}", Int32.Parse(x)))
                     .ToList();  // ToList() is not needed
        return String.Join(String.Empty, splits.ToArray()); // ToArray() not needed in Fx >= 4.0
    }
