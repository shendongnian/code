     var dd = string.Empty;
        var mm = string.Empty;
        var yy = string.Empty;
        string actualDate = "18/07/2012";
        string finalDate = string.Empty;
        if (actualDate.ToString().Contains('/'))
        {
            dd = string.Format("{0:00}", Convert.ToInt32(actualDate.ToString().Split('/')[0]));
            mm = string.Format("{0:00}", Convert.ToInt32(actualDate.ToString().Split('/')[1]));
            yy = string.Format("{0:0000}", Convert.ToInt32(actualDate.ToString().Split('/')[2]));
            finalDate = dd + "/" + mm + "/" + yy;
        }
        string dateString = finalDate; // <-- Valid
        string format = "dd/MM/yyyy";
        DateTime dateTime;
        if (!DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture,
            DateTimeStyles.None, out dateTime))
        {
           lblDate.Text= "Excel Date is not correct format.it should be in dd/mm/yyyy";
        }
        else
        {
            actualDate =
                DateTime.ParseExact(dateString, format,
                                       CultureInfo.InvariantCulture,
                                       DateTimeStyles.None).ToString();
        }
        Label1.Text = actualDate;
