    Regex re = Regex.Match("R1.23", "\d+([,\.]\d+)?");
    if (re.Success)
    {
         double @double = Convert.ToDouble(re.Value, System.Globalization.CultureInfo.InvariantCulture);
    }
