    static bool ParseNumber(string value, out int result)
    {
        if (string.IsNullOrEmpty(value))
        {
            result = 0;
            return false;
        }
        if (value.StartsWith("0x"))
            return int.TryParse(value.Substring(2), NumberStyles.AllowHexSpecifier, null, out result);
        else
            return int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out result);
    }
