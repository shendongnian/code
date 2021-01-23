    string date = "01/04/2013";
            DateTime dtTime;
            if (DateTime.TryParseExact(date, "dd/MM/yyyy",
               System.Globalization.CultureInfo.InvariantCulture,
               System.Globalization.DateTimeStyles.None, out dtTime))
            {
                Console.WriteLine(dtTime);
            }
