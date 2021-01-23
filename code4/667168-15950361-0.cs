    string strDate = "09:19:30.5070000 AM";
    DateTime datDate;           
    if (DateTime.TryParseExact(strDate,"hh:mm:ss.fffffff tt",
        System.Globalization.CultureInfo.InvariantCulture,
        System.Globalization.DateTimeStyles.None, out datDate))
    {
        //Console.WriteLine(datDate.ToString("hh:mm:ss tt"));
         time.Text=datDate.ToString("hh:mm:ss tt");
    
    }
     
