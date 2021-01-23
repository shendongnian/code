    //Parse DOB to check format
    string[] dateList = new string[PersonList.Count()];
    for (int i = 0; i < PersonList.Count(); i++)
    {
        PersonList[i].DOB = PersonList[i].DOB.Replace('-', '/').Replace('.', '/').Trim();
        dateList[i] = PersonList[i].DOB;
    }
    string dateFormat = GetDateFormat(dateList);
    private static string GetDateFormat(string[] date)
    {
        DateTime result;
        CultureInfo ci = CultureInfo.InvariantCulture;
        List<string> fmts = ci.DateTimeFormat.GetAllDateTimePatterns().ToList();
        fmts.Add("yyyy/MM/d");
        fmts.Add("d/MM/yyyy");
        bool error;
        date = date.Where(x => !string.IsNullOrEmpty(x)).ToArray();
        foreach (string a in fmts)
        {
            error = false;
            for (int i = 0; i < date.Count(); i++)
            {
                if (!DateTime.TryParseExact(date[i], a, ci, DateTimeStyles.AssumeLocal, out result))
                {
                    error = true;
                }
            }
            if (error == false)
            {
                return a;
            }          
        }
        throw new CsvToImsException("Error: Date Format is inconsistant or unrecognised");
    }
