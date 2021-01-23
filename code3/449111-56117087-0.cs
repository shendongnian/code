    TimeSpan ts = new TimeSpan(); // this is object of TimeSpan and Suppose it contains
                                  // value 14:00:00
    string tIme = ts.ToString(); // here we convert ts into String and Store in Temprary
                                 // String variable.
     DateTime TheTime = new DateTime(); // Creating the object of DateTime;
     TheTime = Convert.ToDateTime(tIme); // now converting our temporary string into DateTime;
     Console.WriteLine(TheTime.ToString(hh:mm:ss tt));
