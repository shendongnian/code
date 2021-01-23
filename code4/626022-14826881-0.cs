     string sDate1=TextBox1.Text.ToString().Trim();
     string sDate2=TextBox1.Text.ToString().Trim();
     DateTime dt1= DateTime.ParseExact(sDate1,"MM-dd-yyyy",        
                                    System.Globalization.CultureInfo.InvariantCulture);
     DateTime dt2= DateTime.ParseExact(sDate2,"MM-dd-yyyy",        
                                    System.Globalization.CultureInfo.InvariantCulture);
     System.TimeSpan diffr =dt2 - dt1;
     Response.Write(diffr.Days);
