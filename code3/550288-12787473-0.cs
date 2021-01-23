            DateTime testDate = DateTime.ParseExact("2012-08-10T00:51:14.146Z", "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
            Trace.WriteLine(testDate);  //8/9/2012 8:51:14 PM
            Trace.WriteLine(testDate.ToString()); //8/9/2012 8:51:14 PM
            Trace.WriteLine(testDate.ToUniversalTime()); //8/10/2012 12:51:14 AM
           testDate = DateTime.ParseExact("2012-08-10T00:51:14.146Z", "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
            Trace.WriteLine(testDate);//8/10/2012 12:51:14 AM
            Trace.WriteLine(testDate.ToString());//8/10/2012 12:51:14 AM
            Trace.WriteLine(testDate.ToUniversalTime());//8/10/2012 12:51:14 AM
