        static void Main(string[] args)
        {
            foreach (var cultureInfo in System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.AllCultures))
            {
                string longDateWithDayOfWeek = null;
                foreach (var pattern in cultureInfo.DateTimeFormat.GetAllDateTimePatterns('D'))
                {
                    if (pattern.Contains("ddd"))
                    {
                        longDateWithDayOfWeek = pattern;
                        break;
                    }
                }
                bool isFallbackRequired = string.IsNullOrEmpty(longDateWithDayOfWeek);
                if (isFallbackRequired)
                {
                    longDateWithDayOfWeek = "dddd, " + cultureInfo.DateTimeFormat.LongDatePattern;
                }
                System.Console.WriteLine("{0} - {1} {2}", cultureInfo.Name, longDateWithDayOfWeek, (isFallbackRequired) ? " (generated)" : string.Empty);
            }
        }
