    /// <summary>
    /// Indicates whether the specified string is null or empty.
    /// This methods internally uses string.IsNullOrEmpty by trimming the string first which string.IsNullOrEmpty doesn't.
    /// .NET's default string.IsNullOrEmpty method return false if a string is just having one blank space.
    /// For such cases this custom IsNullOrEmptyWithTrim method is useful.
    /// </summary>
    /// <returns><c>true</c> if the string is null or empty or just having blank spaces;<c>false</c> otherwise.</returns> 
    public static bool IsNullOrEmptyWithTrim(this string value)
    {
        bool isEmpty = string.IsNullOrEmpty(value);
        if (isEmpty)
        {
            return true;
        }
        return value.Trim().Length == 0;
    }
