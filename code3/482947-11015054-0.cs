    double dollarValue = -145d; 
    System.Globalization.CultureInfo modCulture = new System.Globalization.CultureInfo("en-US");
         NumberFormatInfo number = modCulture.NumberFormat;
         string mymoney = dollarValue.ToString("C", number);
 
