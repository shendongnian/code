     DateTime start_date;
     DateTime.TryParseExact(strDate, "yyyy-MM-dd hh:mm:ss tt",
                            System.Globalization.CultureInfo.InvariantCulture,
                            System.Globalization.DateTimeStyles.None, out start_date);
     Console.WriteLine(start_date);
