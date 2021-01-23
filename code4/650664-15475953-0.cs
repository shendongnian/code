    string date = "01/04/2013";
                    DateTime myDate = DateTime.ParseExact(date, "dd/MM/yyyy",
                                               System.Globalization.CultureInfo.InvariantCulture);
                    if (myDate > DateTime.Today)
                    {
                        Console.WriteLine("greater than");
                    }
                   else
                    {
                     Console.WriteLine("Less Than");
                    }
    
