    static string CsvEscape(this string value) {
        if (value.Contains(",")) {
            return "\"" + value.Replace("\"", "\"\"") + "\"";
        }
        return value;
    }
