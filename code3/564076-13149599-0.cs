            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("AUS Eastern Standard Time");
            DateTime UKTime = DateTime.Now;
            Console.WriteLine("United Kingdom Time {0}", UKTime);
            DateTime CurrentUTC = UKTime.ToUniversalTime();
            Console.WriteLine("UTC Time {0}", UKTime);
            DateTime OzzieTime = TimeZoneInfo.ConvertTimeFromUtc(CurrentUTC, tzi);
            Console.WriteLine("Ozzie Time {0}",OzzieTime);
            Console.ReadLine();
