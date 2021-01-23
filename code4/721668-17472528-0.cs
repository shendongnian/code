    SqlFunctions.DateAdd("hh", 
                          SqlFunctions.DatePart("hh", d.RequestedDateTimeFrom), 
                          SqlFunctions.DateAdd("mi", 
                                                SqlFunctions.DatePart("mi", d.RequestedDateTimeFrom), 
                                                d.RequestedDate);
