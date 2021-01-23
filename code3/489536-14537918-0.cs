        public string ConvertDateCalendar(DateTime DateConv, string Calendar, string DateLangCulture)
    {
        System.Globalization.DateTimeFormatInfo DTFormat;
        DateLangCulture = DateLangCulture.ToLower();
        /// We can't have the hijri date writen in English. We will get a runtime error - LAITH - 11/13/2005 1:01:45 PM -
        if (Calendar == "Hijri" && DateLangCulture.StartsWith("en-"))
        {
            DateLangCulture = "ar-sa";
        }
        /// Set the date time format to the given culture - LAITH - 11/13/2005 1:04:22 PM -
        DTFormat = new System.Globalization.CultureInfo(DateLangCulture, false).DateTimeFormat;
        /// Set the calendar property of the date time format to the given calendar - LAITH - 11/13/2005 1:04:52 PM -
        switch (Calendar)
        {
            case "Hijri":
                DTFormat.Calendar = new System.Globalization.HijriCalendar();
                break;
            case "Gregorian":
                DTFormat.Calendar = new System.Globalization.GregorianCalendar();
                break;
            default:
                return "";
        }
        /// We format the date structure to whatever we want - LAITH - 11/13/2005 1:05:39 PM -
        DTFormat.ShortDatePattern = "dd/MM/yyyy";
        return (DateConv.Date.ToString("f", DTFormat));
    }
