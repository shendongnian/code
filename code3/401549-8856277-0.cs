    public static DateTime FromQueryResultString(string dttmString) 
    { 
        string[] formats = { "dd/MM/yyyy", "yyyy-MM-dd HH:mm:ss", "dd/MM/yyyy HH:mm:ss"
        IFormatProvider format = Thread.CurrentThread.CurrentCulture.DateTimeFormat;
        DateTime formattedDate = DateTime.ParseExact(dttmString, formats, format, System.Globalization.DateTimeStyles.None);
    } 
