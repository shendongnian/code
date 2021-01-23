     // String to DateTime
     String MyString;
     MyString = "4/29/2013 9:00:00 PM";
    
     DateTime MyDateTime;
     MyDateTime = new DateTime();
     MyDateTime = DateTime.ParseExact(MyString, "M/dd/yyyy hh:mm:ss tt",
                                      null);
