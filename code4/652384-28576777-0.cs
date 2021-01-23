        string sDate = da;
        sDate = sDate.Replace("-", "/");
        sDate = sDate.Replace(".", "/");
        string format = "dd/MM/yyyy";
        DateTime dDate;
        if (DateTime.TryParse(sDate, out dDate))
        {
            //if (DateTime.TryParseExact(sDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dDate))
            //{
            sDate = dDate.ToString("MM/dd/yyyy");
            sDate = sDate.Replace("-", "/");
            sDate = sDate.Replace(".", "/");
        }
        return sDate;
    }
