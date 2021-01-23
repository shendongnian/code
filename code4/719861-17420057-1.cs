    string value = "1234,56";
    NumberStyles style = NumberStyles.AllowDecimalPoint;
    CultureInfo culture = CultureInfo.CreateSpecificCulture("fr-FR"); // or whatever
    decimal number;
    
    if (!Decimal.TryParse(value, style, culture, out number))
    {
        failValidate(FailReason.CannotParse); // Could not parse as a number
    }
    else if (number != Math.Round(number, 2))
    {
        failValidate(FailReason.TooManyDecimals); // More than two decimals provided
    }
    else
    {
        succeedValidate(); // Number was valid and has at most two decimals
    }
