        string datePattern = @"H\Hm\Ms.ff\S";
        var date = new DateTime();
        if (DateTime.TryParseExact("0H0M0.25S", datePattern, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date))
        {
            // Everything you need is in 'date' in just one go :)
            int hours = date.Hour;
            int minute = date.Minute;
            double seconds = (double)date.Second + ((double)date.Millisecond / 1000);
        }
        else 
        {
            // Catch invalid datetime string here
        }
