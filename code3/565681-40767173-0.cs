    public static bool TryParseExcelDateTime(string excelDateTimeAsString, out DateTime dateTime)
    {
        double oaDateAsDouble;
        if (!double.TryParse(excelDateTimeAsString, out oaDateAsDouble)) //this line is Culture dependent!
            return false;
        //[...]
        dateTime = DateTime.FromOADate(oaDateAsDouble);
