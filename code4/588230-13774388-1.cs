    public bool isNumeric(string val, System.Globalization.NumberStyles NumberStyle)
    {
        Double result;
        return Double.TryParse(val,NumberStyle,
    		System.Globalization.CultureInfo.CurrentCulture,out result);
    }
