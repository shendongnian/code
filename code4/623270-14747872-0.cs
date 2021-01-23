    public double UniveralParse(string value)
    {
        double result;
   
        // If we can not parse the "." format...
        if (!double.TryParse(value, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out result))
            // And also can not parse the "," format...
            if (!double.TryParse(value, NumberStyles.Any, CultureInfo.GetCultureInfo("de-DE"), out result))
                // we throw an exception
                throw new ArgumentException("value is not in expected format!");
        // Otherwise we can return the value
        return result;
    }
