    public static string ToStringWithArticle(this DateTime dateTime, string format)
    {
        var dateTimeString = dateTime.ToString(format);
        if (language = "nl-BE")
        {
            dateTimeString = "le " + dateTimeString;
        }
        return dateTimeString;
     }
