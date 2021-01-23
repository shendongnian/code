    public static string ToEnglish(int number)
    {
        var sb = new StringBuilder();
        if (number >= 100) {
            ...
            number %= 100;
        }
        if (sb.Length > 0 && number != 0) {
            sb.Append("and ");
        }
        if (number >= 20) {
            ...
            number %= 10;
        }
        if (sb.Length == 0 || number != 0) {
            ...
        }
        return sb.ToString();
    }
