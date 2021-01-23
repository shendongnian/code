    Private bool TryParsing(String value, out Int32 parsedValue)
    {
        Return Int32.TryParse(value, parsedValue)
    }
    Private bool TryParsing(String value, out Double parsedValue)
    {
        Return Double.TryParse(value, parsedValue)
    }
    Private bool TryParsing(String value, out Decimal parsedValue)
    {
        Return Decimal.TryParse(value, parsedValue)
    }
    Private bool TryParsing(String value, out DateTime parsedValue)
    {
        Return DateTime.TryParse(value, parsedValue)
    }
