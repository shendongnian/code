    using System.Globalization;
    value = "1345,978";
    style = System.Globalization.NumberStyles.AllowDecimalPoint;
    culture = System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR");
    if (Single.TryParse(value, style, culture, out number))
       Console.WriteLine("Converted '{0}' to {1}.", value, number);
    else
       Console.WriteLine("Unable to convert '{0}'.", value);
