    string strDate = "25/03/2013";           
    DateTime datDate;
    DateTime.TryParseExact(strDate , new string[] { "dd/MM/yyyy" },
                           System.Globalization.CultureInfo.InvariantCulture,
                           System.Globalization.DateTimeStyles.None, out datDate);
    Console.WriteLine(datDate);
