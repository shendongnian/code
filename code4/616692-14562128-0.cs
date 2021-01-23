    string myTime = "08:50:00";
                    DateTime currentDateTime = DateTime.UtcNow.Date;
                   string myDateTime = string.Format("{0}-{1}-{2} {3}", currentDateTime.Year, currentDateTime.Month, currentDateTime.Day,
                                  myTime);
    
                   DateTime dt = Convert.ToDateTime(myDateTime, new CultureInfo("en-GB"));
    
                    //or
                    DateTime myNewDatetime = new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day,
                                                          8, 50, 0);
