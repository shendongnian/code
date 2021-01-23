        static void ChangeTimezone()
        {
            // Timezone string here:
            foreach (TimeZoneInfo z in TimeZoneInfo.GetSystemTimeZones())
                Console.WriteLine(z.Id);
            // Use one of those timezone strings
            DateTime localDt = DateTime.Today;
            DateTime utcTime = localDt.ToUniversalTime();
            TimeZoneInfo timeInfo = TimeZoneInfo.FindSystemTimeZoneById("US Eastern Standard Time");
            DateTime estDt = TimeZoneInfo.ConvertTimeFromUtc(utcTime, timeInfo);
            return;
        }
