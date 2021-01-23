        protected static DateTime FromExcelSerialDate(int serialDate)
        {
            if (serialDate > 59) serialDate -= 1; //Excel/Lotus 2/29/1900 bug   
            return new DateTime(1899, 12, 31).AddDays(serialDate);
         }
