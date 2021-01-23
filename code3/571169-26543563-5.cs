        public static DateTime ToEn(string fadate)
        {
            if (fadate.Trim() == "") return DateTime.MinValue;
            int[] farsiPartArray = SplitRoozMahSalNew(fadate);
            return new PersianCalendar().ToDateTime(farsiPartArray[0], farsiPartArray[1], farsiPartArray[2], 0, 0, 0, 0);
        }
 
        private static int[] SplitRoozMahSalNew(string farsiDate)
        {
            int pYear = 0;
            int pMonth = 0;
            int pDay = 0;
            //normalize with one character
            farsiDate = farsiDate.Trim().Replace(@"\", "/").Replace(@"-", "/").Replace(@"_", "/").
                Replace(@",", "/").Replace(@".", "/").Replace(@" ", "/");
            string[] rawValues = farsiDate.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (!farsiDate.Contains("/"))
            {
                if (rawValues.Length != 2)
                    throw new Exception("usually there should be 2 seperator for a complete date");
            }
            else //mostly given in all numeric format like 13930316
            {
                // detect year side and add slashes in right places and continue
            }
            //new simple method which emcompass below methods too
            try
            {
                pYear = int.Parse(rawValues[0].TrimStart(new[] { '0' }).Trim());
                pMonth = int.Parse(rawValues[1].TrimStart(new[] { '0' }).Trim());
                pDay = int.Parse(rawValues[2].TrimStart(new[] { '0' }).Trim());
                // the year usually must be larger than 90
                //or for historic values rarely lower than 33 if 2 digit is given
                if (pYear < 33 && pYear > 0)
                {
                    //swap year and day
                    pYear = pDay;
                    pDay = int.Parse(rawValues[0]); //convert again
                }
                //fix 2 digits of persian strings
                if (pYear.ToString(CultureInfo.InvariantCulture).Length == 2)
                    pYear = pYear + 1300;
                //
                if (pMonth <= 0 || pMonth >= 13)
                    throw new Exception("mahe shamsi must be under 12 ");
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "invalid Persian date format: maybe all 3 numric Sal, Mah,rooz parts are not present. \r\n" + ex);
            }
            return new[] { pYear, pMonth, pDay };
        }
