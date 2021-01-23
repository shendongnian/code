    public static string ToStringWithArticle(this DateTime dateTime, string format)
    {
        var dateTimeString = dateTime.ToString(format);
        if (language = "nl-BE")
        {
            ...
        }
        return dateTimeString;
     }
