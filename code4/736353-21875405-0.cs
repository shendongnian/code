    string strDate = DateTime.ParseExact(yourDateTime, "M/d/yyyy h:mm:ss tt", null).ToString();
            if (strDate.Substring(0, 10).Trim().LastIndexOf(" ", System.StringComparison.Ordinal) == 8)
                strDate = strDate.Substring(0, 8).Trim();
            else
                strDate = strDate.Substring(0, 10).Trim();
            DateTime FinalDate = Convert.ToDateTime(strDate);
    
