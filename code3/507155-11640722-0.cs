    public bool DoubleEqualsString(double doubleValue, string stringValue)
    {
        double convertedValue;
        if (Double.TryParse(stringValue, out convertedValue))
            return convertedValue == doubleValue;
        return false;
    }
